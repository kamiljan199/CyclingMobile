using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float ParallaxSpeed;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    void Update()
    {
        float temp = (cam.transform.position.x * (1 - ParallaxSpeed));
        float dist = (cam.transform.position.x * ParallaxSpeed);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length)
            startpos += 2 * length;
        else if (temp < startpos - length)
            startpos -= 2 * length;
    }
}
