using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BicycleController : MonoBehaviour
{
    public Animator animator;
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

    // Start is called before the first frame update
    void Start()
    {
        levelBeaten = GameObject.Find("LevelBeaten");
        rb = gameObject.GetComponent<Rigidbody2D>();
        movement = 0.0f;
        energy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);

        FindObjectOfType<AudioManager>().Play("bike1");

        LoadSave();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("goldzik: " + player.GetComponent<Player>().gold);

        //Debug.Log("jak szybko zapierdalasz kolarzu?" + velocity);
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

        //if (currentBoost > 0.0f)
        //{
        //    currentBoost -= 0.01f;
        //}
        //else if (currentBoost < 0.0f)
        //{
        //    currentBoost = 0.0f;
        //}

        //if(Time.time < boostTime)
        //{
        //    currentBoost = maxBoost;
        //}
        //else if(Time.time < afterBoostTime)
        //{
        //    currentBoost = -maxBoost;
        //}
        //else
        //{
        //    currentBoost = 0;
        //}

        //Debug.Log("no dumny ty jestes z siebie czlowieku: " + currentBoost);
        if ( boostClicked == true)
        {
            Debug.Log("BOOOST");

            currentBoost = maxBoost;
            boostTime = Time.time + boostTimeDuration;
            //afterBoostTime = Time.time + boostTimeDuration + afterBoostTimeDuration;
            boostParticle.SetActive(true);
            //boostParticle.GetComponent<BoostParticle>().StartParticles();

            //boost = false;
            boostClicked = false;
            AddEnergy(-2.5f);
        }
        else if(Time.time > boostTime)
        {
            boostParticle.SetActive(false);
            //boostParticle.GetComponent<BoostParticle>().StopParticles();
        }

        if (velocity < 250.0f)
        {
            if (afterMovement)
            {

            }
            //else if ((isButtonPressed || Input.GetKey("right")) && energy > 0)
            else if (energy > 0)
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
            //else
            //{
            //movement = 0.0f;
            //energy += 0.2f;
            //}

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

        //recovering energy when running downwards
        if (bike.transform.rotation.z < 0.0f && bike.transform.rotation.z > -90.0f)
        {
            AddEnergy(0.005f);
        }

        currentBoost = 0.0f;
        energyBar.SetEnergy(energy);

        //Debug.Log(GetVelocity());
    }

    private void FixedUpdate()
    {
        if (force > 0)
        {
            //Debug.Log(movement);

            backWheel.AddTorque(-movement * speed * Time.fixedDeltaTime);
            frontWheel.AddTorque(-movement * speed * Time.fixedDeltaTime);
            //bike.AddTorque(movement * bikeTorque * Time.fixedDeltaTime);
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
                //AddEnergy(-0.1f);
                //velocity change 0.0 -> 0.(3)
                x = GetVelocity() / 300.0f;
                return x * LevelInformations.gearUpgrade;
                //return 0.3f;
            }
            else if (GetVelocity() <= 200.0f && GetVelocity() > 100.0f)
            {
                //AddEnergy(-0.05f);
                //velocity change 0.3 -> 0.1
                x = 0.5f - (GetVelocity()) / 1000.0f;
                return x * LevelInformations.gearUpgrade;
                //return 0.05f;
            }
            else 
            {
                //AddEnergy(-0.01f);
                //velocity change 0.1005 -> 0.005
                x = 0.3005f - (GetVelocity()) / 1000.0f;
                return x * LevelInformations.gearUpgrade;
                //return 0.005f;
            }
        }
        else if(gear == 2)
        {
            if (GetVelocity() <= 100.0f)
            {
                //AddEnergy(-0.2f);
                //velocity change 0.0 -> 0.15
                x = GetVelocity()*3 / 3000.0f;
                return x * LevelInformations.gearUpgrade;
                //return 0.1f;
            }
            else if (GetVelocity() <= 200.0f && GetVelocity() > 100.0f)
            {
                //AddEnergy(-0.1f);
                //velocity change 0.16.67 -> 0.204
                x = 0.13f + GetVelocity() / 2700.0f;
                return x * LevelInformations.gearUpgrade;
                //return 0.2f;
            }
            else
            {
                //AddEnergy(-0.05f);
                //velocity change 0.2025 -> 0.0025
                x = 0.6025f - (GetVelocity()) / 5500.0f;
                return x * LevelInformations.gearUpgrade;
                //return 0.005f;
            }
        }
        else
        {
            if (GetVelocity() <= 100.0f)
            {
                //AddEnergy(-0.5f);
                //velocity change 0.0 -> 0.05
                x = GetVelocity() / 2000.0f;
                return x * LevelInformations.gearUpgrade;
                //return 0.05f;
            }
            else if (GetVelocity() <= 200.0f && GetVelocity() > 100.0f)
            {
                //AddEnergy(-0.2f);
                //velocity change 0.05 -> 0.1
                x = GetVelocity() / 2000.0f;
                return x * LevelInformations.gearUpgrade;
                //return 0.1f;
            }
            else
            {
                //AddEnergy(-0.05f);
                //velocity change 0.1 -> 0.2
                x = GetVelocity() / 1000.0f - 0.1f;
                return x * LevelInformations.gearUpgrade;
                //return 0.2f;
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

            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Coin"))
        {
            player.GetComponent<Player>().gold += 1;
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
            
            //Application.Quit();
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
        Debug.Log("Save wczytany pomyslnie.");
    }

}
