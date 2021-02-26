using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInformations : MonoBehaviour
{
    public static int exp = 10;
    public static int gearLevel = 1;
    public static int frameLevel = 1;
    public static int tiresLevel = 1;

    public static float maxSpeed = 300.0f;
    public static float gearUpgrade = 1.0f;


    public int sandNumber;
    public int grassNumber;
    public int asphaltNumber;
    public string nameOfLevel;

    public int GetSandNumber()
    {
        return sandNumber;
    }
    public void SetSandNumber(int newNr)
    {
        sandNumber = newNr;
    }
    public int GetGrassNumber()
    {
        return grassNumber;
    }
    public void SetGrassNumber(int newNr)
    {
        grassNumber = newNr;
    }
    public int GetAsphaltNumber()
    {
        return asphaltNumber;
    }
    public void SetAsphaltNumber(int newNr)
    {
        asphaltNumber = newNr;
    }

}
