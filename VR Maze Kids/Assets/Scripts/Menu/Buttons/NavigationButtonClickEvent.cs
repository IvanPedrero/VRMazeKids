using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationButtonClickEvent : MonoBehaviour
{
    public enum BUTTON_TYPE
    {
        menu_button,
        reload_button,
        pause_button
    }
    public BUTTON_TYPE type = BUTTON_TYPE.menu_button;

    public void DoAction()
    {
        switch (type)
        {
            case BUTTON_TYPE.menu_button:
                MenuButton();
                break;
            case BUTTON_TYPE.reload_button:
                ReloadButton();
                break;
            case BUTTON_TYPE.pause_button:
                PauseButton();
                break;
        }
    }


    void MenuButton()
    {
        NavigationController.instance.GoToMainMenu();
    }

    void ReloadButton()
    {
        NavigationController.instance.ReloadScene();
    }

    void PauseButton()
    {
        PauseController.instance.DoPause();
    }
}
