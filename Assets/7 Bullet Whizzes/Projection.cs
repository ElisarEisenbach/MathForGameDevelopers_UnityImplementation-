using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projection : MonoBehaviour
{
    [SerializeField] Vector3 firstPoint, secondPoint;


    private Vector3 a,e,b,bPrime;
    private float x;

    // Start is called before the first frame update
    void Start()
    {
        a = secondPoint - firstPoint;
        b = transform.position - firstPoint;
        x = Vector3.Dot(a, b) / Vector3.Dot(a, a);
        bPrime = x * a;
        e = bPrime - b;
        Debug.Log("Closest point is " + firstPoint + e);
        LineRenderer lineRenderer = null;
        lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;

        //For drawing line in the world space, provide the x,y,z values
        lineRenderer.SetPosition(0,firstPoint); //x,y and z position of the starting point of the line
        lineRenderer.SetPosition(1, secondPoint); //x,y and z position of the end point of the line
        lineRenderer.startWidth = .2f;
        lineRenderer.endWidth = .2f;


        LineRenderer ShootLine = null;
        ShootLine = new GameObject("Line").AddComponent<LineRenderer>();
        ShootLine.startColor = Color.black;
        ShootLine.endColor = Color.black;
        ShootLine.startWidth = 0.01f;
        ShootLine.endWidth = 0.01f;
        ShootLine.positionCount = 2;
        ShootLine.useWorldSpace = true;

        //For drawing line in the world space, provide the x,y,z values
        ShootLine.SetPosition(0, transform.position); //x,y and z position of the starting point of the line
        ShootLine.SetPosition(1, firstPoint + bPrime); //x,y and z position of the end point of the line
        ShootLine.startWidth = .2f;
        ShootLine.endWidth = .2f;
        ShootLine.startColor = Color.black;
        ShootLine.endColor = Color.black;


    }

    // Update is called once per frame
    void Update()
    {
        while (Input.GetKeyDown(KeyCode.Space))
        {
        }
    }
}
