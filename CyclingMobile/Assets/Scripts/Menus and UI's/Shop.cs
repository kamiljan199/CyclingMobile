using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    public GameObject player;
    public Button buyButton;
    public Button setButton;
    public Text prizeText;
    public Text missingMoney;
    public Text ownedText;
    public bool unavailable;
    //public bool owned;
    public Text notAvailableYet;

    public bool skin0;
    public bool skin1;
    public bool skin2;
    public bool skin3;
    public bool skin4;
    public bool skin5;

    // Start is called before the first frame update
    void Start()
    {
        LoadSave();
        OwnedSkins();
        if (unavailable == true)
        {
            HideUnavailableSkin();
        }    
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
        player.GetComponent<Player>().skin0 = data.skin0;
        player.GetComponent<Player>().skin1 = data.skin1;
        player.GetComponent<Player>().skin2 = data.skin2;
        player.GetComponent<Player>().skin3 = data.skin3;
        player.GetComponent<Player>().skin4 = data.skin4;
        player.GetComponent<Player>().skin5 = data.skin5;
        Debug.Log("Save wczytany pomyslnie.");
    }

    public void ShowSetButton()
    {
        setButton.gameObject.SetActive(true);
    }

    public void HideSetButton()
    {
        setButton.gameObject.SetActive(false);
    }

    public void ShowBuyButton()
    {
        buyButton.gameObject.SetActive(true);
    }

    public void HideBuyButton()
    {
        buyButton.gameObject.SetActive(false);
    }

    public void BuyButton()
    {
        int prize = int.Parse(prizeText.text, System.Globalization.NumberStyles.Integer);
        Debug.Log("prize: " + prize);
        if (player.GetComponent<Player>().gold >= prize)
        {
            //owned = true;
            player.GetComponent<Player>().gold -= prize;
            //zapisac zmiane
            if (skin0 == true)
            {
                player.GetComponent<Player>().skin0 = true;
                SaveSystem.SavePlayer(player.GetComponent<Player>());
            }
            else if (skin1 == true)
            {
                player.GetComponent<Player>().skin1 = true;
                SaveSystem.SavePlayer(player.GetComponent<Player>());
            }
            else if (skin2 == true)
            {
                player.GetComponent<Player>().skin2 = true;
                SaveSystem.SavePlayer(player.GetComponent<Player>());
            }
            else if (skin3 == true)
            {
                player.GetComponent<Player>().skin3 = true;
                SaveSystem.SavePlayer(player.GetComponent<Player>());
            }
            else if (skin4 == true)
            {
                player.GetComponent<Player>().skin4 = true;
                SaveSystem.SavePlayer(player.GetComponent<Player>());
            }
            else if (skin5 == true)
            {
                player.GetComponent<Player>().skin5 = true;
                SaveSystem.SavePlayer(player.GetComponent<Player>());
            }
            
            HideBuyButton();
            ShowSetButton();
            ownedText.gameObject.SetActive(true);
        }
        else
        {
            missingMoney.gameObject.SetActive(true);
            Invoke("HideMissingMoney", 5.0f);
        }
    }

    public void SetButton()
    {
        if (skin1 == true && player.GetComponent<Player>().skin1 == true)
        {
            player.GetComponent<Player>().skinState = 1;
            LevelInformations.maxSpeed = 310.0f;
            LevelInformations.gearUpgrade = 1.1f;
            BicycleController.maxEnergy = 110.0f;
            Debug.Log(player.GetComponent<Player>().skinState);
            SaveSystem.SavePlayer(player.GetComponent<Player>());
        }
        if (skin2 == true && player.GetComponent<Player>().skin2 == true)
        {
            player.GetComponent<Player>().skinState = 2;
            LevelInformations.maxSpeed = 320.0f;
            LevelInformations.gearUpgrade = 1.2f;
            BicycleController.maxEnergy = 120.0f;
            SaveSystem.SavePlayer(player.GetComponent<Player>());
        }
        if (skin3 == true && player.GetComponent<Player>().skin3 == true)
        {
            player.GetComponent<Player>().skinState = 3;
            LevelInformations.maxSpeed = 330.0f;
            LevelInformations.gearUpgrade = 1.3f;
            BicycleController.maxEnergy = 130.0f;
            SaveSystem.SavePlayer(player.GetComponent<Player>());
        }
        if (skin4 == true && player.GetComponent<Player>().skin4 == true)
        {
            player.GetComponent<Player>().skinState = 4;
            LevelInformations.maxSpeed = 340.0f;
            LevelInformations.gearUpgrade = 1.4f;
            BicycleController.maxEnergy = 140.0f;
            SaveSystem.SavePlayer(player.GetComponent<Player>());
        }
    }

    public void HideMissingMoney()
    {
        missingMoney.gameObject.SetActive(false);
    }

    public void HideNotAvailableYet()
    {
        notAvailableYet.gameObject.SetActive(false);
    }

    public void OwnedSkins()
    {
        if (skin0 == true) //&& player.GetComponent<Player>().skin0 == true)
        {
            HideBuyButton();
            ShowSetButton();
            ownedText.gameObject.SetActive(true);
            player.GetComponent<Player>().skin0 = true;
            SaveSystem.SavePlayer(player.GetComponent<Player>());
        }
        else if (skin1 == true && player.GetComponent<Player>().skin1 == true)
        {
            HideBuyButton();
            ShowSetButton();
            ownedText.gameObject.SetActive(true);
            //player.GetComponent<Player>().skin0 = true;
            //SaveSystem.SavePlayer(player.GetComponent<Player>());
        }
        else if (skin2 == true && player.GetComponent<Player>().skin2 == true)
        {
            HideBuyButton();
            ShowSetButton();
            ownedText.gameObject.SetActive(true);
            //player.GetComponent<Player>().skin0 = true;
            //SaveSystem.SavePlayer(player.GetComponent<Player>());
        }
        else if (skin3 == true && player.GetComponent<Player>().skin3 == true)
        {
            HideBuyButton();
            ShowSetButton();
            ownedText.gameObject.SetActive(true);
            //player.GetComponent<Player>().skin0 = true;
            //SaveSystem.SavePlayer(player.GetComponent<Player>());
        }
        else if (skin4 == true && player.GetComponent<Player>().skin4 == true)
        {
            HideBuyButton();
            ShowSetButton();
            ownedText.gameObject.SetActive(true);
            //player.GetComponent<Player>().skin0 = true;
            //SaveSystem.SavePlayer(player.GetComponent<Player>());
        }
        else if (skin5 == true && player.GetComponent<Player>().skin5 == true)
        {
            HideBuyButton();
            ShowSetButton();
            ownedText.gameObject.SetActive(true);
            //player.GetComponent<Player>().skin0 = true;
            //SaveSystem.SavePlayer(player.GetComponent<Player>());
        }
        else
        {
            ShowBuyButton();
            HideSetButton();
            ownedText.gameObject.SetActive(false);
        }
    }

    public void HideUnavailableSkin()
    {
        HideBuyButton();
        HideSetButton();
    }

    public void AddMoney()
    {
        player.GetComponent<Player>().gold += 10;
    }
}
