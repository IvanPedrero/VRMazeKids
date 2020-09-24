using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallRandom : MonoBehaviour
{
    public GameObject obj1, obj2, obj3;
    private int respuestaCorrecta, respuestaNum;
    public TextMesh texto_1, texto_2, texto_3, texto_4;
    Conversion con = new Conversion();
    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
