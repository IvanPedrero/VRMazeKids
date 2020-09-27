using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject activitiesPanel;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainPanel();
    }

    #region UI Management

    private void CloseAllPanels()
    {
        mainPanel.SetActive(false);
        activitiesPanel.SetActive(false);
    }

    public void ShowMainPanel()
    {
        CloseAllPanels();
        mainPanel.SetActive(true);
    }

    public void ShowActivititesPanel()
    {
        print("Showing activitites...");
        CloseAllPanels();
        activitiesPanel.SetActive(true);
    }

    #endregion

    #region Scene Management

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    #endregion
}
