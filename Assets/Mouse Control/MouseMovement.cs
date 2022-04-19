using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{

   float iLastMoveMouseX;
   float iLastMoveMouseY;

    EulerAngle eangle;

    // Start is called before the first frame update
    void Start()
    {
        eangle = GetComponent<EulerAngle>();
    }

    // Update is called once per frame
    void Update()
    {
        float iMouseMovedX = Input.mousePosition.x - iLastMoveMouseX;
        float iMouseMovedY = Input.mousePosition.y - iLastMoveMouseY;

        eangle.pitch += iMouseMovedY*0.05f;
        eangle.yaw += iMouseMovedX*0.05f;

        eangle.Normalize();


        iLastMoveMouseX = Input.mousePosition.x;
        iLastMoveMouseY = Input.mousePosition.y;


        Camera.main.transform.position = transform.position - eangle.ToVector() * 5f;
        Camera.main.transform.LookAt(gameObject.transform);


    }
}
