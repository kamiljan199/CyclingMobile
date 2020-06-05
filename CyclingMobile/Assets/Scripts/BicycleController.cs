using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicycleController : MonoBehaviour
{

    public Rigidbody2D backWheel;
    public Rigidbody2D frontWheel;
    public Rigidbody2D bike;


    public float bikeTorque = 20;
    public float speed = 100;
    public float force = 100;

    private float movement;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if(force > 0)
        {
            backWheel.AddTorque(-movement * speed * Time.fixedDeltaTime);
            frontWheel.AddTorque(-movement * speed * Time.fixedDeltaTime);
            bike.AddTorque(-movement * bikeTorque * Time.fixedDeltaTime);
        }
       

    }
}
