using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public Text gearText;
    public Text tiresText;
    public Text frameText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (LevelInformations.gearLevel == 1)
        {
            gearText.text = "Change your Max Boost on gears from 5 to 10";
        }

        if (LevelInformations.gearLevel == 2)
        {
            gearText.text = "Change your Max Boost on gears from 10 to 15";
        }

        if (LevelInformations.gearLevel == 3)
        {
            gearText.text = "You achieved your max level of gears!!!";
        }

        if (LevelInformations.frameLevel == 1)
        {
            frameText.text = "Change your Max Speed from 300 to 330";
        }

        if (LevelInformations.frameLevel == 2)
        {
            frameText.text = "Change your Max Speed from 330 to 360";
        }

        if (LevelInformations.frameLevel == 3)
        {
            frameText.text = "You achieved your max level of frame!!!";
        }

        if (LevelInformations.tiresLevel == 1)
        {
            tiresText.text = "Change your Max Friction on tires from 5 to 10";
        }

        if (LevelInformations.tiresLevel == 2)
        {
            tiresText.text = "Change your Max Friction on tires from 10 to 15";
        }

        if (LevelInformations.tiresLevel == 3)
        {
            tiresText.text = "You achieved your max level of gears!!!";
        }
    }

    public void OnClickFrame() 
    {
        if (LevelInformations.exp >= 10) 
        {
            LevelInformations.exp = 0;
            LevelInformations.maxSpeed += 30;
            LevelInformations.frameLevel++;
        } 
    }

    public void OnClickGears()
    {
        if (LevelInformations.exp >= 10)
        {
            LevelInformations.exp = 0;
            LevelInformations.gearUpgrade += 0.05f;
            LevelInformations.gearLevel++;
        }
    }

    public void OnClickTires()
    {
        if (LevelInformations.exp >= 10)
        {
            LevelInformations.exp = 0;
            LevelInformations.tiresLevel++;
        }
    }
}
