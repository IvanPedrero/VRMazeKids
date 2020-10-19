using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LearningNumbersN4Controller : MonoBehaviour
{
    //Balloons Number
    Conversion con = new Conversion();
    public GameObject B_1, B_2, B_3, B_4, B_5;
    public GameObject[] B = new GameObject[5];
    public TextMesh dialogo;
    private string a, b, c, d, f;
    public static int respuesta;

    //Score Controller
    public GameObject textWin, textLose;

    //RayCast
    public static int score, wrongAnswer;
    public static string NCorrecto;
    private Int64 RCorrecta;

    // Start is called before the first frame update
    void Start()
    {

        a = UnityEngine.Random.Range(1, 4).ToString();
        b = UnityEngine.Random.Range(1, 4).ToString();
        c = UnityEngine.Random.Range(1, 4).ToString();
        d = UnityEngine.Random.Range(4, 6).ToString();
        f = UnityEngine.Random.Range(4, 6).ToString();

        while (b == c || b == a || c == a)
        {
            if (a == b || a == c)
            {
                a = UnityEngine.Random.Range(1, 4).ToString();
            }
            if (b == c)
            {
                b = UnityEngine.Random.Range(1, 4).ToString();
            }
        }

        while (d == f)
        {
            d = UnityEngine.Random.Range(4, 6).ToString();
        }

        B_1.tag = a;
        B_2.tag = b;
        B_3.tag = c;
        B_4.tag = d;
        B_5.tag = f;

        respuesta = UnityEngine.Random.Range(1, 1000);
        dialogo.text = con.enletras(respuesta.ToString());

        B[0] = B_1;
        B[1] = B_2;
        B[2] = B_3;
        B[3] = B_4;
        B[4] = B_5;

        for (int i = 0; i < 5; i++)
        {
            if (B[i].tag == "1")
            {
                B[i].GetComponentInChildren<TextMesh>().text = ((int)(respuesta / 100)).ToString();
            }

            if (B[i].tag == "2")
            {
                B[i].GetComponentInChildren<TextMesh>().text = ((int)((respuesta % 100) / 10)).ToString();
            }

            if (B[i].tag == "4")
            {
                B[i].GetComponentInChildren<TextMesh>().text = ((int)((respuesta % 100) % 10)).ToString();
            }

            if (B[i].tag == "3")
            {
                B[i].GetComponentInChildren<TextMesh>().text = UnityEngine.Random.Range(0, 10).ToString();
            }

            if (B[i].tag == "5")
            {
                B[i].GetComponentInChildren<TextMesh>().text = UnityEngine.Random.Range(0, 10).ToString();
            }
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
            StartCoroutine(reloadScreen(0));
        }
        else if (wrongAnswer == 3)
        {
            textWin.SetActive(false);
            textLose.SetActive(true);
            Debug.Log("Perdiste");
            wrongAnswer = 0;
            StartCoroutine(reloadScreen(4));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fin()
    {
        if(NCorrecto == null)
        {
            NCorrecto = "0";
        }

        RCorrecta = int.Parse(NCorrecto);
        if (respuesta == RCorrecta)
        {
            if (wrongAnswer != 0)
            {
                wrongAnswer = 0;
            }
            score++;
            //Debug.Log(score);
            StartCoroutine(reloadScreen(4));
        }
        else
        {
            if (score != 0)
            {
                score = 0;
            }
            wrongAnswer++;
            //Debug.Log(score);
            StartCoroutine(reloadScreen(4));
        }

        NCorrecto = "0";
    }

    public IEnumerator reloadScreen(int scene)
    {
        yield return new WaitForSeconds(1f);
        NavigationController.instance.GoToScene(scene);
    }
}
