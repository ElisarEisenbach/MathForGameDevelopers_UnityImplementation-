using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AABBTest))]
public class AABBTestEditor : Editor
{
    protected virtual void OnSceneGUI()
    {
        AABBTest t = (AABBTest)target;
        t.APoint = Handles.PositionHandle(t.APoint, Quaternion.identity);
        t.BPoint = Handles.PositionHandle(t.BPoint, Quaternion.identity);

        for (int i = 0; i < t.boxes.Length; i++)
        {
            t.boxes[i].center = Handles.PositionHandle(t.boxes[i].center, Quaternion.identity);
        }
    }
}