﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicycleController : MonoBehaviour
{
    public ButtonPressed button;
    public EnergyBar energyBar;

    public Rigidbody2D backWheel;
    public Rigidbody2D frontWheel;
    public Rigidbody2D bike;


    public float bikeTorque = 20;
    public float speed = 200;
    public float force = 100;

    private float movement;
    private bool isButtonPressed;

    private float energy;
    public float maxEnergy = 100.0f;


    // Start is called before the first frame update
    void Start()
    {
        movement = 0.0f;
        energy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);
    }

    // Update is called once per frame
    void Update()
    {
        isButtonPressed = button.GetButtonState();

        if ((isButtonPressed || Input.GetKey("right")) && energy > 0)
        {
            if (movement < 1.0f)
            {
                movement += 0.05f;
            }
            else movement = 1.0f;

            energy -= 0.1f;
            energyBar.SetEnergy(energy);
        }

        else if (Input.GetKey("left"))
        {
            if (movement > -1.0f)
            {
                movement -= 0.05f;
            }
            else movement = -1.0f;
        }
    }

    private void FixedUpdate()
    {
        if (force > 0)
        {
            backWheel.AddTorque(-movement * speed * Time.fixedDeltaTime);
            frontWheel.AddTorque(-movement * speed * Time.fixedDeltaTime);
            bike.AddTorque(-movement * bikeTorque * Time.fixedDeltaTime);
        }


    }
}
