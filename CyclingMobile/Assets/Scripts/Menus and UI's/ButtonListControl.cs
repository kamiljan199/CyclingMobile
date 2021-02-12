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
    GameObject player;

    GameObject levelBeaten;
    void Start()
    {
        levelBeaten = GameObject.Find("LevelBeaten");
        player = GameObject.Find("EventSystem");
        LoadSave();

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

    public void LoadSave()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        player.GetComponent<Player>().gold = data.gold;
        player.GetComponent<Player>().grass1State = data.grass1;
        player.GetComponent<Player>().grass2State = data.grass2;
        player.GetComponent<Player>().grass3State = data.grass3;
        player.GetComponent<Player>().grass4State = data.grass4;
        player.GetComponent<Player>().asphalt1State = data.asphalt1;
        player.GetComponent<Player>().asphalt2State = data.asphalt2;
        player.GetComponent<Player>().asphalt3State = data.asphalt3;
        player.GetComponent<Player>().asphalt4State = data.asphalt4;
        player.GetComponent<Player>().sand1State = data.sand1;
        player.GetComponent<Player>().sand2State = data.sand2;
        player.GetComponent<Player>().sand3State = data.sand3;
        player.GetComponent<Player>().sand4State = data.sand4;
        player.GetComponent<Player>().skin0 = data.skin0;
        player.GetComponent<Player>().skin1 = data.skin1;
        player.GetComponent<Player>().skin2 = data.skin2;
        player.GetComponent<Player>().skin3 = data.skin3;
        player.GetComponent<Player>().skin4 = data.skin4;
        player.GetComponent<Player>().skin5 = data.skin5;
        player.GetComponent<Player>().skinState = data.skinState;

        if (data.grass1 == false && data.grass2 == false && data.grass3 == false && data.grass4 == false)
            levelBeaten.GetComponent<LevelInformations>().SetGrassNumber(1);
        else if (data.grass1 == true && data.grass2 == false && data.grass3 == false && data.grass4 == false)
            levelBeaten.GetComponent<LevelInformations>().SetGrassNumber(2);
        else if (data.grass1 == true && data.grass2 == true && data.grass3 == false && data.grass4 == false)
            levelBeaten.GetComponent<LevelInformations>().SetGrassNumber(3);
        else if (data.grass1 == true && data.grass2 == true && data.grass3 == true && data.grass4 == false)
            levelBeaten.GetComponent<LevelInformations>().SetGrassNumber(4);
        else if (data.grass1 == true && data.grass2 == true && data.grass3 == true && data.grass4 == true)
            levelBeaten.GetComponent<LevelInformations>().SetGrassNumber(4);

        if (data.sand1 == false && data.sand2 == false && data.sand3 == false && data.sand4 == false)
            levelBeaten.GetComponent<LevelInformations>().SetSandNumber(1);
        else if (data.sand1 == true && data.sand2 == false && data.sand3 == false && data.sand4 == false)
            levelBeaten.GetComponent<LevelInformations>().SetSandNumber(2);
        else if (data.sand1 == true && data.sand2 == true && data.sand3 == false && data.sand4 == false)
            levelBeaten.GetComponent<LevelInformations>().SetSandNumber(3);
        else if (data.sand1 == true && data.sand2 == true && data.sand3 == true && data.sand4 == false)
            levelBeaten.GetComponent<LevelInformations>().SetSandNumber(4);
        else if (data.sand1 == true && data.sand2 == true && data.sand3 == true && data.sand4 == true)
            levelBeaten.GetComponent<LevelInformations>().SetSandNumber(4);

        if (data.asphalt1 == false && data.asphalt2 == false && data.asphalt3 == false && data.asphalt4 == false)
            levelBeaten.GetComponent<LevelInformations>().SetAsphaltNumber(1);
        else if (data.asphalt1 == true && data.asphalt2 == false && data.asphalt3 == false && data.asphalt4 == false)
            levelBeaten.GetComponent<LevelInformations>().SetAsphaltNumber(2);
        else if (data.asphalt1 == true && data.asphalt2 == true && data.asphalt3 == false && data.asphalt4 == false)
            levelBeaten.GetComponent<LevelInformations>().SetAsphaltNumber(3);
        else if (data.asphalt1 == true && data.asphalt2 == true && data.asphalt3 == true && data.asphalt4 == false)
            levelBeaten.GetComponent<LevelInformations>().SetAsphaltNumber(4);
        else if (data.asphalt1 == true && data.asphalt2 == true && data.asphalt3 == true && data.asphalt4 == true)
            levelBeaten.GetComponent<LevelInformations>().SetAsphaltNumber(4);

        Debug.Log("Save wczytany pomyslnie.");
    }
}
