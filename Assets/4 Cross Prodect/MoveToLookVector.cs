using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLookVector : MonoBehaviour
{

    private static EulerAngle eangle;

    // Start is called before the first frame update
    void Start()
    {
        eangle = GetComponent<EulerAngle>();
    }


    public static Vector3 MoveToLookDir(float x, float z)
    {
        Vector3 forwardVec = eangle.ToVector();
        forwardVec.y = 0; //to not go up
        forwardVec = forwardVec.normalized;

        Vector3 vecRight = Vector3.Cross(Vector3.up, forwardVec);
        Vector3 vel = forwardVec * x + vecRight * z;

        return vel;
    }
}
