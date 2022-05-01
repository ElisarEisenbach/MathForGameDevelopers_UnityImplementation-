using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLookVector : MonoBehaviour
{

    private static EulerAngle eangle;
    private static RotateMatrix rot;

    // Start is called before the first frame update
    void Start()
    {
        eangle = GetComponent<EulerAngle>();
        rot = GetComponent<RotateMatrix>();
    }


    public static Vector3 MoveToLookDir(float x, float z)
    {
        Vector3 forwardVec = eangle.ToVector();
        rot.Vector3 = forwardVec;
        forwardVec.y = 0; //to not go up
        forwardVec = forwardVec.normalized;

        Vector3 vecRight =  Vector3.Cross(Vector3.up, forwardVec);
        Vector3 vel = forwardVec * x + vecRight * z;



        return vel;
    }
    public static Matrix4x4 GetPos()
    {
        Vector3 forwardVec = eangle.ToVector();
        forwardVec.y = 0; //to not go up
        forwardVec = forwardVec.normalized;

        Vector3 vecRight = Vector3.Cross(Vector3.up, forwardVec);
        Matrix4x4 mPlayer = new Matrix4x4(forwardVec, Vector3.up, vecRight,new Vector4(0,0,0,1));
        

        return mPlayer;
    }
}
