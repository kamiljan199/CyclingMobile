using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static bool isPaused = false;
    public static bool hasCollided = false;
    public static int caseForCollision;
    public GameObject popUp1;
    public GameObject popUp2;
    public GameObject popUp3;
    public GameObject popUp4;
    public GameObject popUp5;

    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    // Start is called before the first frame update
    void Start()
    {
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(false);
        popUp1.SetActive(false);
        popUp2.SetActive(false);
        popUp3.SetActive(false);
        popUp4.SetActive(false);
        popUp5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ChangePopUps();
    }

    public void ChangePopUps()
    {
        switch (caseForCollision)
        {
            case 1:
                ChangePopUpButtonState();
                hasCollided = false;
                break;
            case 2:
                ChangePopUpButtonState();
                hasCollided = false;
                break;
            case 3:
                ChangePopUpButtonState();
                hasCollided = false;
                break;
            case 4:
                ChangePopUpButtonState();
                hasCollided = false;
                break;
            case 5:
                ChangePopUpButtonState();
                hasCollided = false;
                break;
        }
    }

    void ChangePopUpButtonState()
    {
        if (hasCollided == true)
        {
            if (isPaused == false)
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        switch (caseForCollision)
        {
            case 1:
                popUp1.SetActive(false);
                Time.timeScale = 1.0f;
                isPaused = false;
                FindObjectOfType<AudioManager>().Play("bike1");
                break;
            case 2:
                popUp2.SetActive(false);
                image1.SetActive(false);
                Time.timeScale = 1.0f;
                isPaused = false;
                FindObjectOfType<AudioManager>().Play("bike1");
                break;
            case 3:
                popUp3.SetActive(false);
                Time.timeScale = 1.0f;
                isPaused = false;
                FindObjectOfType<AudioManager>().Play("bike1");
                break;
            case 4:
                popUp4.SetActive(false);
                image2.SetActive(false);
                Time.timeScale = 1.0f;
                isPaused = false;
                FindObjectOfType<AudioManager>().Play("bike1");
                break;
            case 5:
                popUp5.SetActive(false);
                image3.SetActive(false);
                Time.timeScale = 1.0f;
                isPaused = false;
                FindObjectOfType<AudioManager>().Play("bike1");
                break;
        }
    }

    void Pause()
    {
        switch (caseForCollision) 
        {
            case 1:
                //Vibration.Vibrate(100);
                popUp1.SetActive(true);
                Time.timeScale = 0.0f;
                isPaused = true;
                FindObjectOfType<AudioManager>().Stop("bike1");
                break;
            case 2:
                //Vibration.Vibrate(100);
                popUp2.SetActive(true);
                image1.SetActive(true);
                Time.timeScale = 0.0f;
                isPaused = true;
                FindObjectOfType<AudioManager>().Stop("bike1");
                break;
            case 3:
                //Vibration.Vibrate(100);
                popUp3.SetActive(true);
                Time.timeScale = 0.0f;
                isPaused = true;
                FindObjectOfType<AudioManager>().Stop("bike1");
                break;
            case 4:
                //Vibration.Vibrate(100);
                popUp4.SetActive(true);
                image2.SetActive(true);
                Time.timeScale = 0.0f;
                isPaused = true;
                FindObjectOfType<AudioManager>().Stop("bike1");
                break;
            case 5:
                //Vibration.Vibrate(100);
                popUp5.SetActive(true);
                image3.SetActive(true);
                Time.timeScale = 0.0f;
                isPaused = true;
                FindObjectOfType<AudioManager>().Stop("bike1");
                break;
        }
    }
}
