using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBoss : MonoBehaviour
{
    Matrix4x4 boosmatrix;
    // Start is called before the first frame update
    void Start()
    {
        boosmatrix = Matrix4x4.identity;
        boosmatrix[0, 0] = 3;
        boosmatrix[1, 1] = 3;
        boosmatrix[2, 2] = 3;

        var scaled = boosmatrix.MultiplyPoint(transform.localScale);
        gameObject.transform.localScale = scaled;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
