using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gears : MonoBehaviour
{
    public BicycleController bike;
    public Text gearStateNumber;
    private bool pressedDown;
    private bool pressedUp;
    // Start is called before the first frame update
    void Start()
    {
        gearStateNumber.text = bike.gear.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (pressedDown)
        {
            GearDown();
            pressedDown = false;
        }
        if (pressedUp)
        {
            GearUp();
            pressedUp = false;
        }
        gearStateNumber.text = bike.gear.ToString();
    }

    void GearDown()
    {
        bike.gear--;
        if (bike.gear < 1)
            bike.gear = 1;
    }

    void GearUp()
    {
        bike.gear++;
        if (bike.gear > 3)
            bike.gear = 3;
    }

    public void OnClickDown ()
    {
        pressedDown = true;
    }

    public void OnClickUp()
    {
        pressedUp = true;
    }
}
