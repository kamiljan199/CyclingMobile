using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
    public string nameOfLevel;
    public int numberOfLevel;
    // Start is called before the first frame update
    GameObject levelBeaten;
    Text numberOfLevelText;
    void Start()
    {
        levelBeaten = GameObject.Find("LevelBeaten");
        if (nameOfLevel == "Sand")
        {
            numberOfLevelText = GameObject.Find("SandNumberText").GetComponent<Text>();
        }
        if (nameOfLevel == "Grass")
        {
            numberOfLevelText = GameObject.Find("GrassNumberText").GetComponent<Text>();
        }
        if (nameOfLevel == "Asphalt")
        {
            numberOfLevelText = GameObject.Find("AsphaltNumberText").GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (nameOfLevel == "Sand") {
            numberOfLevelText.text = levelBeaten.GetComponent<LevelInformations>().sandNumber.ToString();
        }
        if (nameOfLevel == "Grass")
        {
            numberOfLevelText.text = levelBeaten.GetComponent<LevelInformations>().grassNumber.ToString();
        }
        if (nameOfLevel == "Asphalt")
        {
            numberOfLevelText.text = levelBeaten.GetComponent<LevelInformations>().asphaltNumber.ToString();
        }
    }

    public void LeveLChangerMethod()
    {
        levelBeaten.GetComponent<LevelInformations>().nameOfLevel = nameOfLevel;
        SceneManager.LoadScene(nameOfLevel+numberOfLevel, LoadSceneMode.Single);
    }
}
