using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public GameObject LosePanel;
    private BicycleController bike;

    // Start is called before the first frame update
    void Start()
    {
        LosePanel.SetActive(false);
        bike = GameObject.FindGameObjectWithTag("Bike").GetComponent<BicycleController>();
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (bike.lost == true)
        {
            Lose();
            bike.lost = false;
        }
    }

    void Lose()
    {
        Vibration.Vibrate(100);
        LosePanel.SetActive(true);
        Time.timeScale = 0.0f;
        FindObjectOfType<AudioManager>().Stop("bike1");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
        FindObjectOfType<AudioManager>().Stop("bike1");
    }

    public void LoadLevelChooser()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
        FindObjectOfType<AudioManager>().Stop("bike1");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        int actualSceneNumber = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(actualSceneNumber);
        //FindObjectOfType<AudioManager>().Start("bike1");
    }

}
