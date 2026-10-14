using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{   

    public GameObject SettingsMenu;
    public bool isSettingsMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestScene()
    {
        SceneManager.LoadScene("Testing");
    }

    public void Settings_BTN()
    {
        

        SettingsMenu.SetActive(true);
        isSettingsMenu = true;


    }

    public void BackBTN()
    {
        if(isSettingsMenu == true)
        {
            SettingsMenu.SetActive(false);
            isSettingsMenu = false;
        }
    } 
}
