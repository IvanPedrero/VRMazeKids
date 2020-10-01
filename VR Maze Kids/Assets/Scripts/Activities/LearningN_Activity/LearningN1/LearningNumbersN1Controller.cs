using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningNumbersN1Controller : MonoBehaviour
{
    //RandomSpawn Apples
    public GameObject apple;
    public GameObject[] appleList;
    public int nApple;

    //Show Answers
    public TextMesh texto_1, texto_2, texto_3;
    public GameObject obj1, obj2, obj3;
    public int numero;
    Conversion con = new Conversion();
    private int respuestaCorrecta;

    //Score Controller
    public GameObject textWin, textLose;

    //CameraRayController
    public static int score, wrongAnswer;

    // Start is called before the first frame update
    void Start()
    {
        NavigationController.instance.CreateMenu();

        //RandomSpawn Apples
        appleList = GameObject.FindGameObjectsWithTag("apple");
        if (appleList.Length == 0)
        {
            appleSpawn();
        }


        //Show Answers
        obj1.tag = "wrongAns";
        obj2.tag = "wrongAns";
        obj3.tag = "wrongAns";
        respuestaCorrecta = UnityEngine.Random.Range(1, 4);

        if (respuestaCorrecta == 1)
        {
            obj1.tag = "goodAns";
            texto_2.text = con.enletras((UnityEngine.Random.Range(0, 21)).ToString());
            texto_3.text = con.enletras((UnityEngine.Random.Range(0, 21)).ToString());
        }
        else if (respuestaCorrecta == 2)
        {
            obj2.tag = "goodAns";
            texto_1.text = con.enletras((UnityEngine.Random.Range(0, 21)).ToString());
            texto_3.text = con.enletras((UnityEngine.Random.Range(0, 21)).ToString());
        }
        else if (respuestaCorrecta == 3)
        {
            obj3.tag = "goodAns";
            texto_1.text = con.enletras((UnityEngine.Random.Range(0, 21)).ToString());
            texto_2.text = con.enletras((UnityEngine.Random.Range(0, 21)).ToString());
        }


        //Score Controller
        Debug.Log("Score:" + score);
        Debug.Log("Wrong:" + wrongAnswer);

        if (score == 3)
        {
            textWin.SetActive(true);
            textLose.SetActive(false);
            Debug.Log("Ganaste");
            score = 0;
            StartCoroutine(reloadScreen(2));
        }
        else if (wrongAnswer == 3)
        {
            textWin.SetActive(false);
            textLose.SetActive(true);
            Debug.Log("Perdiste");
            wrongAnswer = 0;
            StartCoroutine(reloadScreen(1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Show Answers
        if (respuestaCorrecta == 1)
        {
            texto_1.text = con.enletras(nApple.ToString());
        }
        else if (respuestaCorrecta == 2)
        {
            texto_2.text = con.enletras(nApple.ToString());
        }
        else if (respuestaCorrecta == 3)
        {
            texto_3.text = con.enletras(nApple.ToString());
        }
    }

    public void appleSpawn()
    {
        nApple = Random.Range(0, 21);
        for (int i = 0; i < nApple; i++)
        {
            Vector3 randomSpawn = new Vector3(Random.Range(12.12f, 16.35f), Random.Range(5.38f, 8f), Random.Range(0.5f, 0.5f));
            Instantiate(apple, randomSpawn, transform.rotation);
        }

    }

    public void correctAnswers()
    {
        if (wrongAnswer != 0)
        {
            wrongAnswer = 0;
        }
        score++;

        StartCoroutine(reloadScreen(1));
    }

    public void wrongAnswers()
    {
        if (score != 0)
        {
            score = 0;
        }
        wrongAnswer++;

        StartCoroutine(reloadScreen(1));
    }

    public IEnumerator reloadScreen(int scene)
    {
        yield return new WaitForSeconds(1f);
        NavigationController.instance.GoToScene(scene);
    }
}

