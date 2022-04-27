using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
public class CreateMesh : MonoBehaviour
{

    Mesh mesh;

   public Vector3[] vertices;
    int[] triangles;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateShape();
        UpdateMesh();
    }

    public void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

    void CreateShape()
    {
        vertices = new Vector3[]
        {
            new Vector3 (0,0,0),
            new Vector3 (0,1,0),
            new Vector3 (1,0,0),
            new Vector3 (1,1,0)

        };

        triangles = new int[]
        {
            0,1,2,
            1,3,2
        };


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            vertices[2] = new Vector3(1, 2, 2);
            UpdateMesh();
        }
    }

    // Update is called once per frame

}
