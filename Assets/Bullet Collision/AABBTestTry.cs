using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABBTestTry : MonoBehaviour
{
    private InterpolateKeyboardMovement KeyboardMovement;
    private GameObject searchedObject;


    Vector3 startPoint;
    Vector3 endPoint;
    Vector3 intersection;

    // Start is called before the first frame update
    void Start()
    {
        KeyboardMovement = GetComponent<InterpolateKeyboardMovement>();
        searchedObject = GameObject.FindGameObjectWithTag("Enemy");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Vector3 characterDir = KeyboardMovement.Velocity.normalized;
            startPoint = transform.position;
            endPoint = transform.position + characterDir * 10f;
            Vector3 path = endPoint - startPoint;

            var sprite = searchedObject.GetComponent<SpriteRenderer>();

            var enemyBounds = searchedObject.GetComponent<SpriteRenderer>().bounds;

            var fractionLow = (enemyBounds.min.y - startPoint.y) / (endPoint.y - startPoint.y); //length of not touching / all length
            var fractionHigh = (enemyBounds.max.y - startPoint.y) / (endPoint.y - startPoint.y);


            if (fractionHigh < fractionLow)
            {
                var fractionHighCash = fractionHigh;
                fractionHigh = fractionLow;
                fractionLow = fractionHighCash;
            }

            intersection = startPoint + path * fractionLow;

            //      intersection = startPoint + path * LineFraction;
            // if (!float.IsNaN(intersection.x) && float.IsNaN(intersection.y) && float.IsNaN(intersection.z))
            // {
            GameObject.CreatePrimitive(PrimitiveType.Capsule).transform.position = intersection;
            Debug.Log(intersection);
            //   }



        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(startPoint, endPoint);
    }
}
