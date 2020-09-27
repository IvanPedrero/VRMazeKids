using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickEvent : MonoBehaviour
{
    public string functionName;
    public int sceneIndex = -1;

    private MainMenuController mainMenuController;

    private void Start()
    {
        mainMenuController = GameObject.FindObjectOfType<MainMenuController>() ;
    }
    public void RunControllerFunction()
    {
        if(sceneIndex != -1)
            mainMenuController.SendMessage(functionName, sceneIndex);
        else
            mainMenuController.SendMessage(functionName);
    }

}
