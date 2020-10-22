using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour
{
    [SerializeField]
    private Text myText;

    [SerializeField]
    private ButtonListControl buttonControl;

    private string myTextString;

    private string myLevelToLoad;
     
    public void SetText(string textString, string levelText)
    {
        myLevelToLoad = levelText;
        myTextString = textString;
        myText.text = textString;
    }

    public void OnClick()
    {
        Debug.Log(myLevelToLoad);
        buttonControl.ButtonClicked(myLevelToLoad);
    }
}
