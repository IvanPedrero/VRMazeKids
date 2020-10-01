using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LearningNumbersN2Controller : MonoBehaviour
{
    //Score controller
    public GameObject textWin, textLose;

    //Ball Random
    public GameObject obj1, obj2, obj3;
    private int respuestaCorrecta, respuestaNum;
    public TextMesh texto_1, texto_2, texto_3, texto_4;
    Conversion con = new Conversion();

    //CamaraRay
    public static int score, wrongAnswer;

    // Start is called before the first frame update
    void Start()
    {
        //Ball Random

        obj1.tag = "wrongAns";
        obj2.tag = "wrongAns";
        obj3.tag = "wrongAns";
        respuestaNum = (UnityEngine.Random.Range(21, 101));
        respuestaCorrecta = UnityEngine.Random.Range(1, 4);
        texto_4.text = con.enletras(respuestaNum.ToString());

        if (respuestaCorrecta == 1)
        {
            obj1.tag = "goodAns";
            texto_1.text = respuestaNum.ToString();
            texto_2.text = UnityEngine.Random.Range(21, 101).ToString();
            texto_3.text = UnityEngine.Random.Range(21, 101).ToString();
            obj2.GetComponent<ThrowBall>().enabled = false;
            obj3.GetComponent<ThrowBall>().enabled = false;
        }
        else if (respuestaCorrecta == 2)
        {
            obj2.tag = "goodAns";
            texto_2.text = respuestaNum.ToString();
            texto_1.text = UnityEngine.Random.Range(21, 101).ToString();
            texto_3.text = UnityEngine.Random.Range(21, 101).ToString();
            obj3.GetComponent<ThrowBall>().enabled = false;
            obj1.GetComponent<ThrowBall>().enabled = false;
        }
        else if (respuestaCorrecta == 3)
        {
            obj3.tag = "goodAns";
            texto_3.text = respuestaNum.ToString();
            texto_1.text = UnityEngine.Random.Range(21, 101).ToString();
            texto_2.text = UnityEngine.Random.Range(21, 101).ToString();
            obj2.GetComponent<ThrowBall>().enabled = false;
            obj1.GetComponent<ThrowBall>().enabled = false;
        }

        //Score controller
        Debug.Log("Score:" + score);
        Debug.Log("Wrong:" + wrongAnswer);

        if (score == 3)
        {
            textWin.SetActive(true);
            textLose.SetActive(false);
            Debug.Log("Ganaste");
            score = 0;
            StartCoroutine(reloadScreen(3));

        }
        else if (wrongAnswer == 3)
        {
            textWin.SetActive(false);
            textLose.SetActive(true);
            Debug.Log("Perdiste");
            wrongAnswer = 0;
            StartCoroutine(reloadScreen(2));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void correctAnswers()
    {
        if (wrongAnswer != 0)
        {
            wrongAnswer = 0;
        }
        score++;

        StartCoroutine(reloadScreen(2));
    }

    public void wrongAnswers()
    {
        if (score != 0)
        {
            score = 0;
        }
        wrongAnswer++;

        StartCoroutine(reloadScreen(2));
    }

    public IEnumerator reloadScreen(int scene)
    {
        yield return new WaitForSeconds(2f);
        NavigationController.instance.GoToScene(scene);
    }

}
