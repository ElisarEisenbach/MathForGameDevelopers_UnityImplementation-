using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMatrix : MonoBehaviour
{
    Renderer Material;
    public Vector3 Vector3;

    // Start is called before the first frame update
    void Start()
    {
        Material = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var matrix = Matrix4x4.identity;
        Vector3 f = Vector3;
        f.y = 0;
        f = f.normalized;
        Vector3 u = Vector3.up; 
        Vector3 r = Vector3.Cross(u, f).normalized;
        matrix[0,0] = f.x;
        matrix[0,1] = u.x;
        matrix[0,2] = r.x;
        matrix[1,0] = f.y;
        matrix[1,1] = u.y;
        matrix[1,2] = r.y;
        matrix[2,0] = f.z;
        matrix[2,1] = u.z;
        matrix[2,2] = r.z;



        Material.sharedMaterial.SetMatrix("_mymatrix", matrix);
       // Material.sharedMaterial.SetVector(Shader.PropertyToID("_ForwardVec"), Vector3);
    }
}
