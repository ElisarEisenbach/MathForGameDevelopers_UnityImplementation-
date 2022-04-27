using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField]private Vector2 velocity;
    [SerializeField]private Vector2 gravity = new Vector2(0,-2);


    private Vector2 velocityCash;

    // Start is called before the first frame update
    void Start()
    {
    //    gameObject.transform.position = new Vector3(0, 0, 0);
        velocityCash = velocity;
        GetComponent<SpriteRenderer>().color = Random.ColorHSV();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.deltaTime);
        var dt = Time.deltaTime;
        if (dt > 0.15f)
            dt = 0.15f;

        UpdateTransform(dt);
        UpdateVelocity(dt);

        

    }

    private void UpdateVelocity(float dt)
    {
        velocity = velocity + gravity * dt;
    }

    private void UpdateTransform(float dt)
    {
        Vector2 curPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        curPosition = curPosition + velocity * dt;
        gameObject.transform.position = new Vector3(curPosition.x, curPosition.y, gameObject.transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "Up":
                velocity = new Vector2(velocity.x, Mathf.Abs(velocityCash.y) * -1f);
                break;
            case "Down":
                velocity = new Vector2(velocity.x, Mathf.Abs(velocityCash.y));
                break;
            case "Left":
                velocity = new Vector2(Mathf.Abs(velocityCash.x), velocity.y);
                break;
            case "Right":
                velocity = new Vector2(Mathf.Abs(velocityCash.x) * -1f, velocity.y);
                break;
            default:
                velocity = new Vector2((velocity.x) * -1f, velocity.y * -1f);
                break;
        }
    }

}
