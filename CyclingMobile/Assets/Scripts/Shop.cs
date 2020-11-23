using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        LoadSave();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Debug.Log("Save wczytany pomyslnie.");
    }

    public void ShowObject()
    {
        gameObject.SetActive(true);
    }

    public void HideObject()
    {
        gameObject.SetActive(false);
    }

    public void BuyButton()
    {

    }

    public void SetButton()
    {

    }
}
