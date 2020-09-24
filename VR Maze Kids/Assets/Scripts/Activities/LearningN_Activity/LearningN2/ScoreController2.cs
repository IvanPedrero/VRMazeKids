using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreController2 : MonoBehaviour
{
    public GameObject textWin, textLose;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Score:" + CameraRayCastController2.score);
        Debug.Log("Wrong:" + CameraRayCastController2.wrongAnswer);

        if (CameraRayCastController2.score == 3)
        {
            textWin.SetActive(true);
            textLose.SetActive(false);
            Debug.Log("Ganaste");
        }
        else if (CameraRayCastController2.wrongAnswer == 3)
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
