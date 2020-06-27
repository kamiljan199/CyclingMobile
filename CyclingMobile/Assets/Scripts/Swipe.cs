using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;

public class Swipe : MonoBehaviour
{
    public BicycleController bike;
    public Text gearStateNumber;
    public bool tap, swipeUp, swipeDown, swipeLeft, swipeRigth;
    public bool isDragging;
    public Vector2 startTouch, swipeDelta;
    
    void Start()
    {
        
    }

    void Update()
    {
        tap = swipeUp = swipeDown = swipeLeft = swipeRigth = false;

        //mouse
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            Reset();
        }

        //mobile
        if(Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                Reset();
            }
        }

        swipeDelta = Vector2.zero;
        if (isDragging)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        if(swipeDelta.magnitude > 50)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Math.Abs(x) > Math.Abs(y))
            {
                if(x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRigth = true;
                }
            }
            else
            {
                {
                    if (y < 0)
                    {
                        swipeDown = true;
                        GearDown();
                        Debug.Log("up");
                    }
                    else
                    {
                        swipeUp = true;
                        GearUp();
                        Debug.Log("down");
                    }
                }
            }

            Reset();
        }
    }

    void GearDown()
    {
        bike.gear--;
        if (bike.gear < 1)
        {
            bike.gear = 1;
            return;
        }
    }

    void GearUp()
    {
        bike.gear++;
        if (bike.gear > 3)
        {
            bike.gear = 3;
            return;
        }
        if (bike.height < bike.oldHeight)
        {
            bike.boost = true;
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }
}
