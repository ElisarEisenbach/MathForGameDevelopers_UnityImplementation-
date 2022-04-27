using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABBTestTry : MonoBehaviour
{

    [SerializeField] GameObject BulletPrefab;


    private InterpolateKeyboardMovement2D KeyboardMovement;
    private GameObject searchedObject;


    Vector3 startPoint;
    Vector3 endPoint;
    Vector3 intersection;

    // Start is called before the first frame update
    void Start()
    {
        KeyboardMovement = GetComponent<InterpolateKeyboardMovement2D>();
        searchedObject = GameObject.FindGameObjectWithTag("Enemy");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 characterDir = KeyboardMovement.Velocity.normalized;
            startPoint = transform.position;
            endPoint = transform.position + characterDir * 10f;
            Vector3 path = endPoint - startPoint;

            var sprite = searchedObject.GetComponent<SpriteRenderer>();

            var enemyBounds = searchedObject.GetComponent<SpriteRenderer>().bounds;

            float fractionLow = 0;
            float fractionHigh = 0;


            bool intersectionCheck = false;

            intersectionCheck = CheckIntersection(path, enemyBounds, ref fractionLow, ref fractionHigh, 0);
            if (!intersectionCheck)
                intersectionCheck = CheckIntersection(path, enemyBounds, ref fractionLow, ref fractionHigh, 1);

            if (intersectionCheck)
            {

                //      intersection = startPoint + path * LineFraction;
                // if (!float.IsNaN(intersection.x) && float.IsNaN(intersection.y) && float.IsNaN(intersection.z))
                // {
                //var shoot = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                var shoot = Instantiate<GameObject>(BulletPrefab);
                shoot.transform.position = intersection;
                //  var remap = shoot.AddComponent<Remap>();
                //  remap.duration = .3f;
                //  remap.endSize = 5f;
                //  remap.IntersectionTime = Time.time;

            }



        }
    }


    private bool CheckIntersection(Vector3 path, Bounds enemyBounds, ref float fractionLow, ref float fractionHigh, int tryNumber)
    {
        switch (tryNumber)
        {
            case 0:
                fractionLow = (enemyBounds.min.y - startPoint.y) / (endPoint.y - startPoint.y); //length of not touching / all length
                fractionHigh = (enemyBounds.max.y - startPoint.y) / (endPoint.y - startPoint.y);
                break;

            case 1:
                fractionLow = (enemyBounds.min.x - startPoint.x) / (endPoint.x - startPoint.x); //length of not touching / all length
                fractionHigh = (enemyBounds.max.x - startPoint.x) / (endPoint.x - startPoint.x);
                break;

            default:
                break;
        }


        if (fractionHigh < fractionLow) // shot is from up
        {
            var fractionHighCash = fractionHigh;
            fractionHigh = fractionLow;
            fractionLow = fractionHighCash;
        }


        intersection = startPoint + path * fractionLow;


        if (float.IsNaN(intersection.x) || float.IsNaN(intersection.y) || float.IsNaN(intersection.z) || float.IsInfinity(intersection.x)
            || float.IsInfinity(intersection.y) || float.IsInfinity(intersection.z))
            return false;

        if (enemyBounds.min.x > endPoint.x || enemyBounds.max.x < endPoint.x
            || enemyBounds.min.y > endPoint.y || enemyBounds.max.y < endPoint.y)
            return false;
        return true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(startPoint, endPoint);
    }
}
