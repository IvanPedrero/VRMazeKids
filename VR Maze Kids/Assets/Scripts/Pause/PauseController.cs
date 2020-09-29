using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static PauseController instance;

    public bool isPause = false;

    public GameObject pauseOverlay;

    // Execute before start
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void DoPause()
    {
        isPause = !isPause;

        // If pause is true.
        if (isPause == true)
        {
            Time.timeScale = 0;
        }
        // If not pause.
        else
        {
            Time.timeScale = 1;
        }

        pauseOverlay.SetActive(isPause);
    }

}
