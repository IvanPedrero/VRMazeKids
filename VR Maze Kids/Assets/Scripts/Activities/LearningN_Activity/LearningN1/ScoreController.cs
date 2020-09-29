﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    public GameObject textWin, textLose;
    // Start is called before the first frame update
    void Start()
    {

        // NavigationController.instance.CreateMenu();

        Debug.Log("Score:" + CameraRayCastController.score);
        Debug.Log("Wrong:" + CameraRayCastController.wrongAnswer);

        if (CameraRayCastController.score == 3)
        {
            textWin.SetActive(true);
            textLose.SetActive(false);
            Debug.Log("Ganaste");
        }
        else if (CameraRayCastController.wrongAnswer == 3)
        {
            textWin.SetActive(false);
            textLose.SetActive(true);
            Debug.Log("Perdiste");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
