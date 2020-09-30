using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScoreController3 : MonoBehaviour
{
    public GameObject textWin, textLose;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Score:" + CameraRayCastController3.score);
        Debug.Log("Wrong:" + CameraRayCastController3.wrongAnswer);

        if (CameraRayCastController3.score == 3)
        {
            textWin.SetActive(true);
            textLose.SetActive(false);
            Debug.Log("Ganaste");
        }
        else if (CameraRayCastController3.wrongAnswer == 3)
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
