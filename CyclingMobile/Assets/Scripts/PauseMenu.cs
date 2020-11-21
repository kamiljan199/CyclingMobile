using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenu;
    public static bool isButtonPressed = false;
    public GameObject pauseButton;

    // Update is called once per frame
    void Update()
    {
        ChangePauseButtonState();
        /*
        if (isButtonPressed == true)
        {
            if (isPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        } */
    }

    void ChangePauseButtonState()
    {
        if (isButtonPressed == true)
        {
            if (isPaused == true)
            {
                Resume();
                isPaused = false;
                isButtonPressed = false;
            }
            else
            {
                Pause();
                isPaused = true;
                isButtonPressed = false;
            }
        }
    }

    public void PressPauseButton()
    {
        if (isButtonPressed == false)
        {
            isButtonPressed = true;
        }
        else if (isButtonPressed == true)
        {
            isButtonPressed = false;
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    void Pause()
    {
        Vibration.Vibrate(100);
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        isPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}


