using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityScript.Steps;

public class GemsNumber : MonoBehaviour
{
    public GameObject obj1, obj2, obj3, cof1, cof2, cof3;
    private int respuestaCorrecta, respuestaNum;
    Conversion con = new Conversion();
    public TextMesh texto_1, texto_2, texto_3;
    private string a, b, c, d, e, f;
    private int [] numOrd = new int [3];
    private TextMesh texto_;
    // Start is called before the first frame update
    void Start()
    {
        a = UnityEngine.Random.Range(1, 4).ToString();
        b = UnityEngine.Random.Range(1, 4).ToString();
        c = UnityEngine.Random.Range(1, 4).ToString();

        while(b == c || b == a || c == a)
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

        obj1.tag = a;
        obj2.tag = b;
        obj3.tag = c;

        texto_1.tag = a;
        texto_2.tag = b;
        texto_3.tag = c;

        numOrd[0] = UnityEngine.Random.Range(100, 501);
        numOrd[1] = UnityEngine.Random.Range(100, 501);
        numOrd[2] = UnityEngine.Random.Range(100, 501);
  

        Array.Sort(numOrd);

        if(texto_1.tag == "1")
        {
            texto_1.text = numOrd[0].ToString();
            //obj1.name = "gem1";
            if(texto_2.tag == "2")
            {
                texto_2.text = numOrd[1].ToString();
                //obj2.name = "gem2";
                texto_3.text = numOrd[2].ToString();
                //obj3.name = "gem3";
            }
            else
            {
                texto_2.text = numOrd[2].ToString();
                //obj2.name = "gem2";
                texto_3.text = numOrd[1].ToString();
                //obj3.name = "gem3";
            }
        }else if(texto_2.tag == "1")
        {
            texto_2.text = numOrd[0].ToString();
            //obj2.name = "gem2";
            if (texto_1.tag == "2")
            {
                texto_1.text = numOrd[1].ToString();
                //obj1.name = "gem1";
                texto_3.text = numOrd[2].ToString();
                //obj3.name = "gem3";
            }
            else
            {
                texto_1.text = numOrd[2].ToString();
                //obj1.name = "gem1";
                texto_3.text = numOrd[1].ToString();
                //obj3.name = "gem3";
            }
        }
        else if (texto_3.tag == "1")
        {
            texto_3.text = numOrd[0].ToString();
            //obj3.name = "gem3";
            if (texto_1.tag == "2")
            {
                texto_1.text = numOrd[1].ToString();
                //obj1.name = "gem1";
                texto_2.text = numOrd[2].ToString();
                //obj2.name = "gem2";
            }
            else
            {
                texto_1.text = numOrd[2].ToString();
                //obj1.name = "gem1";
                texto_2.text = numOrd[1].ToString();
                //obj2.name = "gem2";
            }
        }
        
        cof1.tag = "1";
        cof2.tag = "2";
        cof3.tag = "3";



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
