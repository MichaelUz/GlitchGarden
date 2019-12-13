using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{


    //Opens a Panel
    public void OpenPanel(GameObject panel)
    {
        MenuController menuController = FindObjectOfType<MenuController>();
        menuController.OpenPanel(panel);
    }

    //Opens the previously opened panel
    public void OpenPreviousPanel()
    {
        MenuController menuController = FindObjectOfType<MenuController>();
        menuController.OpenPreviousPanel();
    }
    

    //Quit Application
    public void QuitApplication()
    {
        Application.Quit();
    }
}
