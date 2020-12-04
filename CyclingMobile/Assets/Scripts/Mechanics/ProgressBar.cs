using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    public Transform bike;
    public Transform flag;
    private float start;
    private float end;
    //public float current;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        start = bike.position.x / flag.position.x;
        end = 1.0f;
        slider.value = start;
        //current = bike.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //current = bike.position.x;
        slider.value = bike.position.x / flag.position.x;
    }
    /*
    public void IncrementProgress(float newValue)
    {
        slider.value += newValue;
    }
    */
}
