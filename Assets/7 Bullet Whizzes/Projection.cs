using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projection : MonoBehaviour
{
    [SerializeField] Vector3 firstPoint, secondPoint;


    private Vector3 a,e,b,bPrime;
    private float x;
    private int clicks = 0;

    // Start is called before the first frame update
    void Start()
    {
       


    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            if (clicks == 0)
            {
                firstPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                firstPoint.z = 0;
                CreatePrimitiveInClickedPos(firstPoint);
                clicks++;
            }
            else if (clicks == 1)
            {
                secondPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                secondPoint.z = 0;
                CreatePrimitiveInClickedPos(secondPoint);
                clicks = 0;
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            e = GetE();

            CreateLine(firstPoint, secondPoint);

            CreateLine(transform.position, firstPoint + bPrime);

        }
    }

    private Vector3 GetE()
    {
        a = secondPoint - firstPoint;
        b = transform.position - firstPoint;
        x = Vector3.Dot(a, b) / Vector3.Dot(a, a);
        bPrime = x * a;
        return (bPrime - b);
    }

    private void CreateLine(Vector3 start, Vector3 end)
    {
        LineRenderer lineRenderer = null;
        lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;

        //For drawing line in the world space, provide the x,y,z values
        lineRenderer.SetPosition(0, start); //x,y and z position of the starting point of the line
        lineRenderer.SetPosition(1, end); //x,y and z position of the end point of the line
        lineRenderer.startWidth = .2f;
        lineRenderer.endWidth = .2f;
    }

    private void CreatePrimitiveInClickedPos(Vector3 pos)
    {
        var primitive = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        primitive.transform.position = pos;
        primitive.transform.localScale = new Vector3(.2f, .2f, .2f);
    }
}
