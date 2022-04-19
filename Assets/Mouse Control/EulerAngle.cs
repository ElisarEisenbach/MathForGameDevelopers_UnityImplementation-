using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EulerAngle : MonoBehaviour
{

    public float pitch;
    public float yaw;
    public float roll;


    public void Normalize()
    {
        if (pitch > 89)
            pitch = 89;
        if (pitch < -89)
            pitch = -89;

        while (yaw < -180)
            yaw += 360;
        while (yaw > 180)
            yaw -= 360;
    }
    public Vector3 ToVector()
    {
        Vector3 result;

        result.x = Mathf.Cos(yaw) * Mathf.Cos(pitch); //Pitch
        result.y = Mathf.Sin(pitch); //Yaw
        result.z = Mathf.Sin(yaw) * Mathf.Cos(pitch); //roll

        return result;
    }

}
