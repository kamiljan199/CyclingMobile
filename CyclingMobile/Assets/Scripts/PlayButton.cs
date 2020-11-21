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

    public void OnClickUpgrades() => SceneManager.LoadScene("ExpShop", LoadSceneMode.Single);

    public void OnClickBack() => SceneManager.LoadScene("LevelChoser", LoadSceneMode.Single);

    public void OnClick()
    {
        Debug.Log("poziom here: grass1 -> " + player.GetComponent<Player>().grass1State);
        string path = Path.Combine(Application.persistentDataPath, "s1.eo");
        if (File.Exists(path) == false)
        {
            Debug.Log("Save nie istnieje, tworze...");
            SaveSystem.SavePlayer(player.GetComponent<Player>());
        }
        else
        {
            PlayerData data = SaveSystem.LoadPlayer();
            player.GetComponent<Player>().gold = data.gold;
            player.GetComponent<Player>().grass1State = data.grass1;
            player.GetComponent<Player>().grass2State = data.grass2;
            player.GetComponent<Player>().asphalt1State = data.asphalt1;
            player.GetComponent<Player>().asphalt2State = data.asphalt2;
            player.GetComponent<Player>().sand1State = data.sand1;
            player.GetComponent<Player>().sand2State = data.sand2;
            Debug.Log("Save wczytany pomyslnie.");
        }

        SceneManager.LoadScene("LevelChoser", LoadSceneMode.Single);
    }
}
