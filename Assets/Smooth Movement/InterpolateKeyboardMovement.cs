﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class InterpolateKeyboardMovement : MonoBehaviour
{
    public Vector3 Gravity;

    Interoplate interpolator;
    Vector3 GoalVel;
    Vector3 currentVel;

    private void Start()
    {
        interpolator = GetComponent<Interoplate>();
        GoalVel = interpolator.GoalVel;
    }

    private KeyCode lastPushedKey;


    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GoalVel.x = 15;
            GoalVel.y = 0;
            lastPushedKey = KeyCode.W;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            GoalVel.y = -15;
            GoalVel.x = 0;
            lastPushedKey = KeyCode.A;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            GoalVel.x = -15;
            GoalVel.y = 0;
            lastPushedKey = KeyCode.S;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            GoalVel.y = 15;
            GoalVel.x = 0;
            lastPushedKey = KeyCode.D;
        }
        else
        {
            KeyRelese(lastPushedKey);
        }

        var x = interpolator.Approach(GoalVel.x, currentVel.x, Time.deltaTime * 20f);
        var z = interpolator.Approach(GoalVel.y, currentVel.y, Time.deltaTime * 20f);
        currentVel = new Vector2(x, z);

        var vel = MoveToLookVector.MoveToLookDir(x, z);
       // vel = new Vector3(x,0,z); //before adding the cross product

        transform.position = transform.position + vel * Time.deltaTime;




    }

    private void KeyRelese(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.W:
                GoalVel.x = 0;
                break;
            case KeyCode.A:
                GoalVel.y = 0;
                break;
            case KeyCode.S:
                GoalVel.x = 0;
                break;
            case KeyCode.D:
                GoalVel.y = 0;
                break;

            default:
                break;
        }
    }
}
