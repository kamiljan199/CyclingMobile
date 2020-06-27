using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BicycleController : MonoBehaviour
{
    public ButtonPressed button;
    public EnergyBar energyBar;

    public Rigidbody2D backWheel;
    public Rigidbody2D frontWheel;
    public Rigidbody2D bike;
    private Rigidbody2D rb;

    public GameObject endText;


    public float bikeTorque = 20;
    public float speed = 200;
    public float force = 100;

    private float movement;
    private bool isButtonPressed;

    public float height = 0;
    public float oldHeight = 0;
    private float velocity = 0;
    public bool boost = false;
    private float maxBoost = 1.0f;
    private float currentBoost = 0.0f;
    private bool afterMovement = false;

    private float boostTimeDuration = 1.0f;
    private float afterBoostTimeDuration = 1.0f;
    private float boostTime = -1.0f;
    private float afterBoostTime = -2.0f;

    private float energy;
    public float maxEnergy = 100.0f;

    public int gear = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        movement = 0.0f;
        energy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);
    }

    // Update is called once per frame
    void Update()
    {
        oldHeight = height;
        height = bike.gameObject.transform.position.y;
        velocity = GetVelocity();

        isButtonPressed = button.GetButtonState();

        //if (currentBoost > 0.0f)
        //{
        //    currentBoost -= 0.01f;
        //}
        //else if (currentBoost < 0.0f)
        //{
        //    currentBoost = 0.0f;
        //}

        if(Time.time < boostTime)
        {
            currentBoost = maxBoost;
        }
        else if(Time.time < afterBoostTime)
        {
            currentBoost = -maxBoost;
        }
        else
        {
            currentBoost = 0;
        }

        //Debug.Log(currentBoost);
        if (boost == true)
        {
            currentBoost = maxBoost;
            boostTime = Time.time + boostTimeDuration;
            afterBoostTime = Time.time + boostTimeDuration + afterBoostTimeDuration;
            boost = false;
        }

        if (velocity < 300.0f)
        {
            if(afterMovement)
            {

            }
            else if ((isButtonPressed || Input.GetKey("right")) && energy > 0)
            {
                //if (movement < 1.0f)
                //{
                //    movement += 0.5f * gear * 0.5f;
                //}
                //else movement = 1.0f * gear * 0.5f;

                movement = GetMovement() + currentBoost;
            }
            else if (Input.GetKey("left"))
            {
                if (movement > -1.0f)
                {
                    movement -= 0.05f * gear * 0.5f;
                }
                else movement = -1.0f * gear * 0.5f;
            }
            else
            {
                movement = 0.0f;
                energy += 0.2f;
            }
            energyBar.SetEnergy(energy);
        }

        
        //Debug.Log(GetVelocity());
    }

    private void FixedUpdate()
    {
        if (force > 0)
        {
            Debug.Log(movement);

            backWheel.AddTorque(-movement * speed * Time.fixedDeltaTime);
            frontWheel.AddTorque(-movement * speed * Time.fixedDeltaTime);
            bike.AddTorque(-movement * bikeTorque * Time.fixedDeltaTime);
        }


    }

    private float GetVelocity()
    {
        return rb.velocity.x * rb.velocity.x + rb.velocity.y * rb.velocity.y;
    }

    private float GetMovement()
    {
        if(gear == 1)
        {
            if(GetVelocity() < 100.0f)
            {
                AddEnergy(-0.1f);
                return 0.6f;
            }
            else if (GetVelocity() < 200.0f && GetVelocity() > 100.0f)
            {
                AddEnergy(-0.05f);
                return 0.2f;
            }
            else 
            {
                AddEnergy(-0.01f);
                return 0.01f;
            }
        }
        else if(gear == 2)
        {
            if (GetVelocity() < 100.0f)
            {
                AddEnergy(-0.2f);
                return 0.3f;
            }
            else if (GetVelocity() < 200.0f && GetVelocity() > 100.0f)
            {
                AddEnergy(-0.1f);
                return 0.4f;
            }
            else
            {
                AddEnergy(-0.05f);
                return 0.05f;
            }
        }
        else
        {
            if (GetVelocity() < 100.0f)
            {
                AddEnergy(-0.5f);
                return 0.1f;
            }
            else if (GetVelocity() < 200.0f && GetVelocity() > 100.0f)
            {
                AddEnergy(-0.2f);
                return 0.1f;
            }
            else
            {
                AddEnergy(-0.05f);
                return 0.1f;
            }
        }
    }

    private void AddEnergy(float addition)
    {
        energy += addition;


        if (energy < 0)
            energy = 0;
        if (energy > 100)
            energy = 100;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnergyDrink"))
        {
            AddEnergy(50.0f);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("End"))
        {
            Debug.Log("el");
            endText.SetActive(true);
            //Application.Quit();
            SceneManager.LoadScene("LevelChoser", LoadSceneMode.Single);
        }
    }

}
