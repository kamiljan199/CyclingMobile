using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class PlayButton : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
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
        LoadSave();
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
        SceneManager.LoadScene("LevelChoser", LoadSceneMode.Single);
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
