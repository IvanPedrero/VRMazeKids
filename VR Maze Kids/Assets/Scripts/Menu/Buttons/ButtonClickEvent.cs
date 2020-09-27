using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickEvent : MonoBehaviour
{

    public enum BUTTON_TYPE
    {
        panel_changer,
        scene_changer,
        activity_changer
    }public BUTTON_TYPE type = BUTTON_TYPE.scene_changer;

    public string functionName;
    public int sceneIndex = -1;
    public MainMenuController.ACTIVITIES activityType;



    private MainMenuController mainMenuController;

    private void Start()
    {
        mainMenuController = FindObjectOfType<MainMenuController>() ;
    }
    public void RunControllerFunction()
    {
        if(type == BUTTON_TYPE.scene_changer)
            mainMenuController.SendMessage(functionName, sceneIndex);

        else if(type == BUTTON_TYPE.panel_changer)
            mainMenuController.SendMessage(functionName);

        else if (type == BUTTON_TYPE.activity_changer)
            mainMenuController.SendMessage(functionName, activityType);
    }

}
