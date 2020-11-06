using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startposX;
    public GameObject cam;
    public float ParallaxSpeed;

    void Start()
    {
        startposX = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    void Update()
    {
        float temp = (cam.transform.position.x * (1 - ParallaxSpeed));
        float dist = (cam.transform.position.x * ParallaxSpeed);

        transform.position = new Vector3(startposX + dist,  cam.transform.position.y, transform.position.z);

        if (temp >= startposX + length)
            startposX += (length * 2);
        else if (temp <= startposX - length)
            startposX -= (length * 2);

        
    }
}
