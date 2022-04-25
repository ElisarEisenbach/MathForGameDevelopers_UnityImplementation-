using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public SpriteRenderer Line;
    public Vector3 Velocity;

    private Interoplate interoplate;
    private float top;
    private float buttom;
    bool isUp = true;
    // Start is called before the first frame update
    void Start()
    {
        interoplate = GetComponent<Interoplate>();
        top = Line.bounds.max.y;
        buttom = Line.bounds.min.y;
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0;
        if (isUp)
        {
            x = interoplate.Approach(top, transform.position.y, .02f);
            if (x == top)
            {
                isUp = false;
            }
        }
        else
        {
            x = interoplate.Approach(buttom, transform.position.y, .02f);
            if (x == buttom)
            {
                isUp = true;
            }
        }

        transform.position = new Vector3(transform.position.x, x, transform.position.z);

    }
}
