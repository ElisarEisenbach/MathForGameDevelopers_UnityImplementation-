using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projection : MonoBehaviour
{

    public SpriteRenderer GameObjectToFind;
    public SpriteRenderer Line;

    private Vector3 bulletStartPos;

    // Start is called before the first frame update
    void Start()
    {
        bulletStartPos = GameObjectToFind.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        while (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 b = transform.position - bulletStartPos ;
        }
    }
}
