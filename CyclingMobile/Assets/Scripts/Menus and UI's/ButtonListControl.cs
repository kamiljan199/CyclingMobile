﻿using System.Collections;
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

    void Start()
    {
        player = GameObject.Find("EventSystem");
        LoadSave();

        if (biome == "grass")
        {
            Debug.Log(LevelCompleted.grass1Static);
            Debug.Log(LevelCompleted.grass2Static);
            Debug.Log(LevelCompleted.grass3Static);
            Debug.Log(LevelCompleted.grass4Static);
            if (LevelCompleted.grass1Static == true)
            {
                GameObject button = Instantiate(buttonTemlate) as GameObject;
                button.SetActive(true);

                button.GetComponent<ButtonListButton>().SetText("Grass 1", "Grass1");

                button.transform.SetParent(buttonTemlate.transform.parent, false);
            }
            if (LevelCompleted.grass2Static == true)
            {
                GameObject button = Instantiate(buttonTemlate) as GameObject;
                button.SetActive(true);

                button.GetComponent<ButtonListButton>().SetText("Grass 2", "Grass2");

                button.transform.SetParent(buttonTemlate.transform.parent, false);
            }
            if (LevelCompleted.grass3Static == true)
            {
                GameObject button = Instantiate(buttonTemlate) as GameObject;
                button.SetActive(true);

                button.GetComponent<ButtonListButton>().SetText("Grass 3", "Grass3");

                button.transform.SetParent(buttonTemlate.transform.parent, false);
            }
            if (LevelCompleted.grass4Static == true)
            {
                GameObject button = Instantiate(buttonTemlate) as GameObject;
                button.SetActive(true);

                button.GetComponent<ButtonListButton>().SetText("Grass 4", "Grass4");

                button.transform.SetParent(buttonTemlate.transform.parent, false);
            }
        }

        if (biome == "sand")
        {
            Debug.Log(LevelCompleted.sand1Static);
            Debug.Log(LevelCompleted.sand2Static);
            Debug.Log(LevelCompleted.sand3Static);
            Debug.Log(LevelCompleted.sand4Static);
            if (LevelCompleted.sand1Static == true)
            {
                GameObject button = Instantiate(buttonTemlate) as GameObject;
                button.SetActive(true);

                button.GetComponent<ButtonListButton>().SetText("Sand 1", "Sand1");

                button.transform.SetParent(buttonTemlate.transform.parent, false);
            }
            if (LevelCompleted.sand2Static == true)
            {
                GameObject button = Instantiate(buttonTemlate) as GameObject;
                button.SetActive(true);

                button.GetComponent<ButtonListButton>().SetText("Sand 2", "Sand2");

                button.transform.SetParent(buttonTemlate.transform.parent, false);
            }
            if (LevelCompleted.sand3Static == true)
            {
                GameObject button = Instantiate(buttonTemlate) as GameObject;
                button.SetActive(true);

                button.GetComponent<ButtonListButton>().SetText("Sand 3", "Sand3");

                button.transform.SetParent(buttonTemlate.transform.parent, false);
            }
            if (LevelCompleted.sand4Static == true)
            {
                GameObject button = Instantiate(buttonTemlate) as GameObject;
                button.SetActive(true);

                button.GetComponent<ButtonListButton>().SetText("Sand 4", "Sand4");

                button.transform.SetParent(buttonTemlate.transform.parent, false);
            }
        }

        if (biome == "asphalt")
        {
            Debug.Log(LevelCompleted.asphalt1Static);
            Debug.Log(LevelCompleted.asphalt2Static);
            Debug.Log(LevelCompleted.asphalt3Static);
            Debug.Log(LevelCompleted.asphalt4Static);
            if (LevelCompleted.asphalt1Static == true)
            {
                GameObject button = Instantiate(buttonTemlate) as GameObject;
                button.SetActive(true);

                button.GetComponent<ButtonListButton>().SetText("Asphalt 1", "Asphalt1");

                button.transform.SetParent(buttonTemlate.transform.parent, false);
            }
            if (LevelCompleted.asphalt2Static == true)
            {
                GameObject button = Instantiate(buttonTemlate) as GameObject;
                button.SetActive(true);

                button.GetComponent<ButtonListButton>().SetText("Asphalt 2", "Asphalt2");

                button.transform.SetParent(buttonTemlate.transform.parent, false);
            }
            if (LevelCompleted.asphalt3Static == true)
            {
                GameObject button = Instantiate(buttonTemlate) as GameObject;
                button.SetActive(true);

                button.GetComponent<ButtonListButton>().SetText("Asphalt 3", "Asphalt3");

                button.transform.SetParent(buttonTemlate.transform.parent, false);
            }
            if (LevelCompleted.asphalt4Static == true)
            {
                GameObject button = Instantiate(buttonTemlate) as GameObject;
                button.SetActive(true);

                button.GetComponent<ButtonListButton>().SetText("Asphalt 4", "Asphalt4");

                button.transform.SetParent(buttonTemlate.transform.parent, false);
            }
        }
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

        //if (data.grass1 == false && data.grass2 == false && data.grass3 == false && data.grass4 == false)
        //    levelBeaten.GetComponent<LevelInformations>().SetGrassNumber(1);
        //else if (data.grass1 == true && data.grass2 == false && data.grass3 == false && data.grass4 == false)
        //    levelBeaten.GetComponent<LevelInformations>().SetGrassNumber(2);
        //else if (data.grass1 == true && data.grass2 == true && data.grass3 == false && data.grass4 == false)
        //    levelBeaten.GetComponent<LevelInformations>().SetGrassNumber(3);
        //else if (data.grass1 == true && data.grass2 == true && data.grass3 == true && data.grass4 == false)
        //    levelBeaten.GetComponent<LevelInformations>().SetGrassNumber(4);
        //else if (data.grass1 == true && data.grass2 == true && data.grass3 == true && data.grass4 == true)
        //    levelBeaten.GetComponent<LevelInformations>().SetGrassNumber(4);

        //if (data.sand1 == false && data.sand2 == false && data.sand3 == false && data.sand4 == false)
        //    levelBeaten.GetComponent<LevelInformations>().SetSandNumber(1);
        //else if (data.sand1 == true && data.sand2 == false && data.sand3 == false && data.sand4 == false)
        //    levelBeaten.GetComponent<LevelInformations>().SetSandNumber(2);
        //else if (data.sand1 == true && data.sand2 == true && data.sand3 == false && data.sand4 == false)
        //    levelBeaten.GetComponent<LevelInformations>().SetSandNumber(3);
        //else if (data.sand1 == true && data.sand2 == true && data.sand3 == true && data.sand4 == false)
        //    levelBeaten.GetComponent<LevelInformations>().SetSandNumber(4);
        //else if (data.sand1 == true && data.sand2 == true && data.sand3 == true && data.sand4 == true)
        //    levelBeaten.GetComponent<LevelInformations>().SetSandNumber(4);

        //if (data.asphalt1 == false && data.asphalt2 == false && data.asphalt3 == false && data.asphalt4 == false)
        //    levelBeaten.GetComponent<LevelInformations>().SetAsphaltNumber(1);
        //else if (data.asphalt1 == true && data.asphalt2 == false && data.asphalt3 == false && data.asphalt4 == false)
        //    levelBeaten.GetComponent<LevelInformations>().SetAsphaltNumber(2);
        //else if (data.asphalt1 == true && data.asphalt2 == true && data.asphalt3 == false && data.asphalt4 == false)
        //    levelBeaten.GetComponent<LevelInformations>().SetAsphaltNumber(3);
        //else if (data.asphalt1 == true && data.asphalt2 == true && data.asphalt3 == true && data.asphalt4 == false)
        //    levelBeaten.GetComponent<LevelInformations>().SetAsphaltNumber(4);
        //else if (data.asphalt1 == true && data.asphalt2 == true && data.asphalt3 == true && data.asphalt4 == true)
        //    levelBeaten.GetComponent<LevelInformations>().SetAsphaltNumber(4);

        Debug.Log("Save wczytany pomyslnie.");
    }
}
