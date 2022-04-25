using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remap : MonoBehaviour
{
    public float duration;
    public float endSize;
    public float IntersectionTime;

    private float startScale;
    // Start is called before the first frame update
    void Start()
    {
        //   creationTime = Time.time;
        startScale = transform.localScale.x;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 20);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < IntersectionTime + duration)
        {
            var remapped = Remapping(Time.time, IntersectionTime, IntersectionTime + duration, startScale, startScale + endSize);
            gameObject.transform.localScale = new Vector3(startScale + remapped, startScale + remapped, 1);

            var ColorRemap = Remapping(Time.time, IntersectionTime, IntersectionTime + duration, 0, 225);
            Color color = new Color(225 / 255, ColorRemap / 255f , 225 / 255);
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", color);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(startScale + endSize, startScale + endSize, startScale + endSize);
            Destroy(gameObject);
        }
    }

    public float Remapping(float x, float t1, float t2, float s1, float s2)
    {
        float yellow = (x - t1) / (t2 - t1);
        float green = yellow * (s2 - s1) + s1;
        return green;
    }


  



}
