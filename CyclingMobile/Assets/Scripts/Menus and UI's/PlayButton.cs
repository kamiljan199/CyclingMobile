﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class PlayButton : MonoBehaviour
{
    public GameObject player;
    public bool isTutorial;
    //GameObject levelBeaten;

    // Start is called before the first frame update
    void Start()
    {
        //levelBeaten = GameObject.Find("LevelBeaten");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickUpgrades()
    {
        LoadSave();
        SceneManager.LoadScene("ExpShop", LoadSceneMode.Single);
    }

    public void OnClickShop()
    {
        LoadSave();
        SceneManager.LoadScene("ItemShop", LoadSceneMode.Single);
    }

    public void OnClickBack() 
    {
        //LoadSave();
        SaveSystem.SavePlayer(player.GetComponent<Player>());
        SceneManager.LoadScene("LevelChoser", LoadSceneMode.Single); 
    }

    public void OnClick()
    {
        string path = Path.Combine(Application.persistentDataPath, "s1.eo");
        if (File.Exists(path) == false)
        {
            Debug.Log("Save nie istnieje, tworze...");
            SaveSystem.SavePlayer(player.GetComponent<Player>());
        }
        else
        {
            LoadSave();
        }

        Debug.Log("goldzik -> " + player.GetComponent<Player>().gold);
        if (isTutorial == false)
        {
            SceneManager.LoadScene("LevelChoser", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
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
        /*
        if (data.grass1 == true && data.grass2 == true)
        {
            levelBeaten.GetComponent<LevelInformations>().SetGrassNumber(2);
        }
        if (data.sand1 == true && data.sand2 == true)
        {
            levelBeaten.GetComponent<LevelInformations>().SetSandNumber(2);
        }
        if (data.asphalt1 == true && data.asphalt2 == true)
        {
            levelBeaten.GetComponent<LevelInformations>().SetAsphaltNumber(2);
        }*/
        Debug.Log("Save wczytany pomyslnie.");
    }
}
