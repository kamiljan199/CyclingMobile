using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick() => SceneManager.LoadScene("LevelChoser", LoadSceneMode.Single);

    public void OnClickUpgrades() => SceneManager.LoadScene("ExpShop", LoadSceneMode.Single);

    public void OnClickBack() => SceneManager.LoadScene("Menu", LoadSceneMode.Single);
}
