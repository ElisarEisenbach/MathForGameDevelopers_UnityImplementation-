using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AABBTest : MonoBehaviour
{
    public Bounds[] boxes;

    public Vector3 APoint;
    public Vector3 BPoint;

    private void OnSceneGUI()
    {
        APoint = Handles.PositionHandle(APoint, Quaternion.identity);
        BPoint = Handles.PositionHandle(BPoint, Quaternion.identity);
    }
    private void OnDrawGizmos()
    {
        if (boxes == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(APoint, BPoint);

        Vector3 closestIntersection = APoint;
        float smallestFraction = float.MaxValue;
        for (int i = 0; i < boxes.Length; i++)
        {
            var box = boxes[i];

            Color c = Color.cyan * (i + 1) / boxes.Length;
            c.a = 0.5f;
            Gizmos.color = c;
            Gizmos.DrawCube(box.center, box.extents * 2);//we multiply by 2 because this draw function receive the complete size of the box while the extents is only half of it.
            Vector3 intersection;
            float fraction;
            if (LineAABBIntersection(box, APoint, BPoint, out intersection, out fraction))
            {
                if (fraction < smallestFraction)
                {
                    smallestFraction = fraction;
                    closestIntersection = intersection;
                }
            }
        }
        Gizmos.color = Color.red;
        Gizmos.DrawLine(APoint, closestIntersection);
    }

    private bool LineAABBIntersection(Bounds aabbBox, Vector3 v0, Vector3 v1, out Vector3 vectorIntersection, out float fraction)
    {
        vectorIntersection = Vector3.zero;
        fraction = 0;

        float f_low = 0;
        float f_high = 1;
        if (!ClipLine(0, aabbBox, v0, v1, ref f_low, ref f_high))
            return false;
        if (!ClipLine(1, aabbBox, v0, v1, ref f_low, ref f_high))
            return false;
        if (!ClipLine(2, aabbBox, v0, v1, ref f_low, ref f_high))
            return false;

        Vector3 b = v1 - v0;
        vectorIntersection = v0 + b * f_low;
        fraction = f_low;
        return true;
    }

    private bool ClipLine(int dimension, Bounds aabbBox, Vector3 v0, Vector3 v1, ref float f_low, ref float f_high)
    {
        float axisMin;
        float axisMax;
        float axisV0;
        float axisV1;

        switch (dimension)
        {
            case 0:
                axisMin = aabbBox.min.x;
                axisMax = aabbBox.max.x;
                axisV0 = v0.x;
                axisV1 = v1.x;
                break;
            case 1:
                axisMin = aabbBox.min.y;
                axisMax = aabbBox.max.y;
                axisV0 = v0.y;
                axisV1 = v1.y;
                break;
            case 2:
                axisMin = aabbBox.min.z;
                axisMax = aabbBox.max.z;
                axisV0 = v0.z;
                axisV1 = v1.z;
                break;
            default:
                Debug.LogError($"ClipLine: Wrong dimension '{dimension}'");
                return false;
        }


        float f_dim_low = (axisMin - axisV0) / (axisV1 - axisV0);
        float f_dim_high = (axisMax - axisV0) / (axisV1 - axisV0);

        if (f_dim_high < f_dim_low)
        {
            float temp = f_dim_high;
            f_dim_high = f_dim_low;
            f_dim_low = temp;
        }
        if (f_dim_high < f_low)
            return false;
        if (f_dim_low > f_high)
            return false;

        f_low = Mathf.Max(f_dim_low, f_low);
        f_high = Mathf.Min(f_dim_high, f_high);

        if (f_low > f_high)
            return false;

        return true;
    }
}



