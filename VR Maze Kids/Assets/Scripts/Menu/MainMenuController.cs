using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public enum ACTIVITIES
    {
        learning_numbers,
        add_and_sub,
        mult_and_div
    }; ACTIVITIES activityType = ACTIVITIES.learning_numbers;

    public GameObject mainPanel;
    public GameObject activitiesPanel;

    [Header("Activity Level Panels : ")]
    public GameObject learningNumbersLevelsPanel;
    public GameObject addAndSubLevelsPanel;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainPanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            PauseController.instance.DoPause();
        }
    }

    #region UI Management

    private void CloseAllPanels()
    {
        mainPanel.SetActive(false);
        activitiesPanel.SetActive(false);
        learningNumbersLevelsPanel.SetActive(false);
        addAndSubLevelsPanel.SetActive(false);
    }

    public void ShowMainPanel()
    {
        CloseAllPanels();
        mainPanel.SetActive(true);
    }

    public void ShowActivititesPanel()
    {
        CloseAllPanels();
        activitiesPanel.SetActive(true);
    }

    public void ShowActivityLevelPanel(ACTIVITIES type)
    {
        CloseAllPanels();
        switch (type)
        {
            case ACTIVITIES.learning_numbers:
                learningNumbersLevelsPanel.SetActive(true);
                break;
            case ACTIVITIES.add_and_sub:
                addAndSubLevelsPanel.SetActive(true);
                break;
            case ACTIVITIES.mult_and_div:
                print("Showing mult and div...");
                break;
        }
    }

    #endregion

    #region Scene Management

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    #endregion
}
