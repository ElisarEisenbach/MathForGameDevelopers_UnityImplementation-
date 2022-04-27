using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interoplate : MonoBehaviour
{
    public Vector2 GoalVel;

   public float Approach(float goal, float current, float dt)
    {
        var diff = goal - current;

        if (diff > dt) //there is more distance to go throw then the dt, so we will add dt
            return current + dt;
        if (diff < -dt) //if diff is nagative, we check if it's smaller than minus of dt (diff= -2, -dt=0.5 --> )
            return current - dt;
        

        return goal;
    }
}
