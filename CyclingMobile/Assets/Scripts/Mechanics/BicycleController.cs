using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BicycleController : MonoBehaviour
{
    public Animator animator;
    public Animator BicycleControllerAnimator;
    public ButtonPressed button;
    public EnergyBar energyBar;

    public Rigidbody2D backWheel;
    public Rigidbody2D frontWheel;
    public Rigidbody2D bike;
    private Rigidbody2D rb;

    public GameObject endText;
    public GameObject boostParticle;
    public GameObject confettiParticle;


    public float bikeTorque = 20;
    public float speed = 200;
    public float force = 100;

    public float movement;
    private bool isButtonPressed;

    public float height = 0;
    public float oldHeight = 0;
    public float velocity = 0;
    public bool boost = false;
    private float maxBoost = 6.0f;
    private float currentBoost = 0.0f;
    private bool afterMovement = false;

    private float boostTimeDuration = 1f;
    private float afterBoostTimeDuration = 1.0f;
    private float boostTime = -1.0f;
    private float afterBoostTime = -2.0f;

    private float energy;
    public float maxEnergy = 100.0f;

    public int gear = 1;
    public bool boostClicked = false;
    GameObject levelBeaten;

    private int playanim = 0;

    public GameObject player;
    public GameObject flag;

    private float newBikeProgress;
    private float oldBikeProgress;
    public bool lost;

    private void Awake()
    {
        LoadSave();
        Debug.Log(player.GetComponent<Player>().skinState);
        BicycleControllerAnimator.SetInteger("skinState", player.GetComponent<Player>().skinState);
    }

    void Start()
    {
        
        levelBeaten = GameObject.Find("LevelBeaten");
        rb = gameObject.GetComponent<Rigidbody2D>();
        movement = 0.0f;
        energy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);

        FindObjectOfType<AudioManager>().Play("bike1");

        oldBikeProgress = this.transform.position.x / flag.transform.position.x * 100.0f;
        newBikeProgress = oldBikeProgress;
        lost = false;
    }

    void Update()
    {
        if (animator.GetBool("pressed") == true)
        {
            playanim++;
        }
        if (playanim == 200)
        {
            playanim = 0;
            animator.SetBool("pressed", false);
        }
        oldHeight = height;
        height = bike.gameObject.transform.position.y;
        velocity = GetVelocity();

        isButtonPressed = button.GetButtonState();

        
        if ( boostClicked == true)
        {
            Debug.Log("BOOOST");

            currentBoost = maxBoost;
            boostTime = Time.time + boostTimeDuration;
            boostParticle.SetActive(true);

            boostClicked = false;
            AddEnergy(-2.5f);
        }
        else if(Time.time > boostTime)
        {
            boostParticle.SetActive(false);
        }

        if (velocity < 250.0f)
        {
            if (afterMovement)
            {

            }
            else if (energy > 0)
            {
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

        }
        else if(velocity > LevelInformations.maxSpeed)
        {
            velocity = LevelInformations.maxSpeed;
            movement = 0.0f;
        }
        else
        {
            movement = 0.0f;
        }

        if (bike.transform.rotation.z < 0.0f && bike.transform.rotation.z > -90.0f)
        {
            AddEnergy(0.005f);
        }

        currentBoost = 0.0f;
        energyBar.SetEnergy(energy);

        newBikeProgress = this.transform.position.x / flag.transform.position.x * 100.0f;
        if (newBikeProgress >= oldBikeProgress)
        {
            Debug.Log("NICE!");
            oldBikeProgress = newBikeProgress;
        }
        else if (newBikeProgress < oldBikeProgress - 5.0f)
        {
            Debug.Log("LOST YOU SUCKER!");
            lost = true;
        }
    }

    private void FixedUpdate()
    {
        if (force > 0)
        {
            backWheel.AddTorque(-movement * speed * Time.fixedDeltaTime);
            frontWheel.AddTorque(-movement * speed * Time.fixedDeltaTime);
        }
    }

    private float GetVelocity()
    {
        return rb.velocity.x * rb.velocity.x + rb.velocity.y * rb.velocity.y;
    }

    private float GetMovement()
    {
        float x;

        if (gear == 1)
        {
            if(GetVelocity() <= 100.0f)
            {
                x = GetVelocity() / 300.0f;
                return x * LevelInformations.gearUpgrade;
            }
            else if (GetVelocity() <= 200.0f && GetVelocity() > 100.0f)
            {
                x = 0.5f - (GetVelocity()) / 1000.0f;
                return x * LevelInformations.gearUpgrade;
            }
            else 
            {
                x = 0.3005f - (GetVelocity()) / 1000.0f;
                return x * LevelInformations.gearUpgrade;
            }
        }
        else if(gear == 2)
        {
            if (GetVelocity() <= 100.0f)
            {
                x = GetVelocity()*3 / 3000.0f;
                return x * LevelInformations.gearUpgrade;
            }
            else if (GetVelocity() <= 200.0f && GetVelocity() > 100.0f)
            {
                x = 0.13f + GetVelocity() / 2700.0f;
                return x * LevelInformations.gearUpgrade;
            }
            else
            {
                x = 0.6025f - (GetVelocity()) / 5500.0f;
                return x * LevelInformations.gearUpgrade;
            }
        }
        else
        {
            if (GetVelocity() <= 100.0f)
            {
                x = GetVelocity() / 2000.0f;
                return x * LevelInformations.gearUpgrade;
            }
            else if (GetVelocity() <= 200.0f && GetVelocity() > 100.0f)
            {
                x = GetVelocity() / 2000.0f;
                return x * LevelInformations.gearUpgrade;
            }
            else
            {
                x = GetVelocity() / 1000.0f - 0.1f;
                return x * LevelInformations.gearUpgrade;
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
            FindObjectOfType<AudioManager>().Play("drink");
            Debug.Log("EnergyDrink collected.");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Coin"))
        {
            player.GetComponent<Player>().gold += 1;
            Debug.Log("Coin collected.");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("End"))
        {
            FindObjectOfType<AudioManager>().Stop("bike1");

            if (levelBeaten.GetComponent<LevelInformations>().nameOfLevel == "Sand")
            {
                levelBeaten.GetComponent<LevelInformations>().sandNumber++;
            }
            if (levelBeaten.GetComponent<LevelInformations>().nameOfLevel == "Grass")
            {
                levelBeaten.GetComponent<LevelInformations>().grassNumber++;
            }
            if (levelBeaten.GetComponent<LevelInformations>().nameOfLevel == "Asphalt")
            {
                levelBeaten.GetComponent<LevelInformations>().asphaltNumber++;
            }
            Debug.Log("el");
            LevelInformations.exp += 10;
            endText.SetActive(true);
            
            if (flag.GetComponent<LevelCompleted>().grass1 == true)
            {
                player.GetComponent<Player>().grass1State = true;
            }
            else if (flag.GetComponent<LevelCompleted>().grass2 == true)
            {
                player.GetComponent<Player>().grass2State = true;
            }
            else if (flag.GetComponent<LevelCompleted>().asphalt1 == true)
            {
                player.GetComponent<Player>().asphalt1State = true;
            }
            else if (flag.GetComponent<LevelCompleted>().asphalt2 == true)
            {
                player.GetComponent<Player>().asphalt2State = true;
            }
            else if (flag.GetComponent<LevelCompleted>().sand1 == true)
            {
                player.GetComponent<Player>().sand1State = true;
            }
            else if (flag.GetComponent<LevelCompleted>().sand2 == true)
            {
                player.GetComponent<Player>().sand2State = true;
            }

            SaveSystem.SavePlayer(player.GetComponent<Player>());
            
            SceneManager.LoadScene("LevelChoser", LoadSceneMode.Single);
        }
    }

    public void ApplyBoost()
    {
        animator.SetBool("pressed", true);
        boostClicked = true;
        FindObjectOfType<AudioManager>().Play("tap");

        if ((velocity > 90 && velocity <110) || (velocity > 190 && velocity<210))
        {
            Vibration.Vibrate();
            Instantiate(confettiParticle, transform);
        }
    }
    public void LoadSave()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        player.GetComponent<Player>().gold = data.gold;
        player.GetComponent<Player>().grass1State = data.grass1;
        player.GetComponent<Player>().grass2State = data.grass2;
        player.GetComponent<Player>().asphalt1State = data.asphalt1;
        player.GetComponent<Player>().asphalt2State = data.asphalt2;
        player.GetComponent<Player>().sand1State = data.sand1;
        player.GetComponent<Player>().sand2State = data.sand2;
        player.GetComponent<Player>().skin0 = data.skin0;
        player.GetComponent<Player>().skin1 = data.skin1;
        player.GetComponent<Player>().skin2 = data.skin2;
        player.GetComponent<Player>().skin3 = data.skin3;
        player.GetComponent<Player>().skin4 = data.skin4;
        player.GetComponent<Player>().skin5 = data.skin5;
        player.GetComponent<Player>().skinState = data.skinState;
        Debug.Log("Save wczytany pomyslnie.");
    }

}
