using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboarding : MonoBehaviour
{
    [SerializeField] GameObject player;

    MeshFilter mesh;
    CreateMesh createMesh;

    Vector3 f, r, u;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>();
        createMesh = GetComponent<CreateMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        f = (transform.position - player.transform.position);
        r = Vector3.Cross(-Vector3.up, f).normalized;
        u = Vector3.Cross(f, -r).normalized;

       createMesh.vertices[0] = (-u - r);
       createMesh.vertices[1] = (r - u);
       createMesh.vertices[2] = (u - r);
        createMesh.vertices[3] = (u + r);
        createMesh.UpdateMesh();
        

    }
}

