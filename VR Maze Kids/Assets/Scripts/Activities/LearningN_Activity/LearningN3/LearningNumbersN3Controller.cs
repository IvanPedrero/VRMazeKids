using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityScript.Steps;

public class LearningNumbersN3Controller : MonoBehaviour
{
    //Gems Number
    Conversion con = new Conversion();
    public TextMesh texto_1, texto_2, texto_3;
    private string a, b, c;
    public int[] numOrd = new int[3];
    public int[] num = new int[3];

    //ScoreController
    public GameObject textWin, textLose;

    //RayCast
    public static int score, wrongAnswer, neg, neg2;
    public GameObject chest1, chest2, chest3;

    // Start is called before the first frame update
    void Start()
    {

        //Gems Number
        a = UnityEngine.Random.Range(1, 4).ToString();
        b = UnityEngine.Random.Range(1, 4).ToString();
        c = UnityEngine.Random.Range(1, 4).ToString();

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

        texto_1.tag = a;
        texto_2.tag = b;
        texto_3.tag = c;

        numOrd[0] = UnityEngine.Random.Range(100, 501);
        numOrd[1] = UnityEngine.Random.Range(100, 501);
        numOrd[2] = UnityEngine.Random.Range(100, 501);

        Array.Sort(numOrd);

        if (texto_1.tag == "1")
        {
            texto_1.text = numOrd[0].ToString();

            if (texto_2.tag == "2")
            {
                texto_2.text = numOrd[1].ToString();
                texto_3.text = numOrd[2].ToString();
            }
            else
            {
                texto_2.text = numOrd[2].ToString();
                texto_3.text = numOrd[1].ToString();
            }
        }
        else if (texto_2.tag == "1")
        {
            texto_2.text = numOrd[0].ToString();
            if (texto_1.tag == "2")
            {
                texto_1.text = numOrd[1].ToString();
                texto_3.text = numOrd[2].ToString();
            }
            else
            {
                texto_1.text = numOrd[2].ToString();
                texto_3.text = numOrd[1].ToString();
            }
        }
        else if (texto_3.tag == "1")
        {
            texto_3.text = numOrd[0].ToString();

            if (texto_1.tag == "2")
            {
                texto_1.text = numOrd[1].ToString();
                texto_2.text = numOrd[2].ToString();
            }
            else
            {
                texto_1.text = numOrd[2].ToString();
                texto_2.text = numOrd[1].ToString();
            }
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
            StartCoroutine(reloadScreen(4));

        }
        else if (wrongAnswer == 3)
        {
            textWin.SetActive(false);
            textLose.SetActive(true);
            Debug.Log("Perdiste");
            wrongAnswer = 0;
            StartCoroutine(reloadScreen(3));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fin()
    {
        num[0] = int.Parse(chest1.GetComponentInChildren<TextMesh>().text);
        num[1] = int.Parse(chest2.GetComponentInChildren<TextMesh>().text);
        num[2] = int.Parse(chest3.GetComponentInChildren<TextMesh>().text);

        for (int i = 0; i < 3; i++)
        {
            if (num[i] != numOrd[i])
            {
                neg++;
            }
            else
            {
                neg2++;
            }
        }
        if (neg != 0)
        {
            score = 0;
            wrongAnswer++;
            neg = 0;
            StartCoroutine(reloadScreen(3));
        }
        else if (neg2 == 3)
        {
            score++;
            wrongAnswer = 0;
            neg2 = 0;
            StartCoroutine(reloadScreen(3));
        }
    }

    public IEnumerator reloadScreen(int scene)
    {
        yield return new WaitForSeconds(2f);
        NavigationController.instance.GoToScene(scene);
    }
}
