using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string profileName;
    public int gold;
    public int skinState;
    public bool grass1;
    public bool grass2;
    public bool asphalt1;
    public bool asphalt2;
    public bool sand1;
    public bool sand2;
    public bool skin0;
    public bool skin1;
    public bool skin2;
    public bool skin3;
    public bool skin4;
    public bool skin5;

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
        skin0 = bc.skin0;
        skin1 = bc.skin1;
        skin2 = bc.skin2;
        skin3 = bc.skin3;
        skin4 = bc.skin4;
        skin5 = bc.skin5;
        skinState = bc.skinState;
    }


}
