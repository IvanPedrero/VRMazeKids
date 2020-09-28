using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreController4 : MonoBehaviour
{
    public GameObject textWin, textLose;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Score:" + CameraRayCastController4.score);
        Debug.Log("Wrong:" + CameraRayCastController4.wrongAnswer);

        if (CameraRayCastController4.score == 3)
        {
            textWin.SetActive(true);
            textLose.SetActive(false);
            Debug.Log("Ganaste");
        }
        else if (CameraRayCastController4.wrongAnswer == 3)
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