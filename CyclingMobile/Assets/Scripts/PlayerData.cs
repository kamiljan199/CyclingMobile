using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string profileName;
    public int gold;
    public bool grass1;
    public bool grass2;
    public bool asphalt1;
    public bool asphalt2;
    public bool sand1;
    public bool sand2;

    public PlayerData(Player bc)
    {
        gold = bc.gold;
        //profileName = bc.profileName;
        //completedLevels = bc.completedLevels;
        grass1 = bc.grass1State;
        grass2 = bc.grass2State;
        asphalt1 = bc.asphalt1State;
        asphalt2 = bc.asphalt2State;
        sand1 = bc.sand1State;
        sand2 = bc.sand2State;
    }


}
