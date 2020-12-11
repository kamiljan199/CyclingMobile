using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemlate;

    public string biome;

    private string importantStuff;

    GameObject levelBeaten;
    void Start()
    {
        levelBeaten = GameObject.Find("LevelBeaten");

        if (biome == "grass")
        {
            for (int i = 1; i <= levelBeaten.GetComponent<LevelInformations>().grassNumber; i++)
            {
                GameObject button = Instantiate(buttonTemlate) as GameObject;
                button.SetActive(true);

                button.GetComponent<ButtonListButton>().SetText("Grass " + i, "Grass" + i);

                button.transform.SetParent(buttonTemlate.transform.parent, false);
            }
        }

        if (biome == "sand")
        {
            for (int i = 1; i <= levelBeaten.GetComponent<LevelInformations>().sandNumber; i++)
            {
                GameObject button = Instantiate(buttonTemlate) as GameObject;
                button.SetActive(true);

                button.GetComponent<ButtonListButton>().SetText("Sand " + i, "Sand" + i);

                button.transform.SetParent(buttonTemlate.transform.parent, false);
            }
        }

        if (biome == "asphalt")
        {
            for (int i = 1; i <= levelBeaten.GetComponent<LevelInformations>().grassNumber; i++)
            {
                GameObject button = Instantiate(buttonTemlate) as GameObject;
                button.SetActive(true);

                button.GetComponent<ButtonListButton>().SetText("Asphalt " + i, "Asphalt" + i);

                button.transform.SetParent(buttonTemlate.transform.parent, false);
            }
        }
    }

    public void ButtonClicked(string s1)
    {
        string s2 = s1;
        s1 = s1.Remove(s1.Length - 1);
        levelBeaten.GetComponent<LevelInformations>().nameOfLevel = s1;
        SceneManager.LoadScene(s2);
    }
}
