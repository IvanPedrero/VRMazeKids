using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAnswers : MonoBehaviour
{
    public TextMesh texto_0, texto_1, texto_2, texto_3, texto_4, texto_5;
    public GameObject obj1, obj2, obj3;
    public int numero;
    Conversion con = new Conversion();
    private int respuestaCorrecta;
    void Start()
    {
        //Debug.Log(RandomSpawn.nApple);
        //texto.text = con.enletras(num);
        /*texto_1.text = con.enletras((UnityEngine.Random.Range(0, 20)).ToString());
        texto_2.text = con.enletras((UnityEngine.Random.Range(0, 20)).ToString());
        texto_3.text = con.enletras((UnityEngine.Random.Range(0, 20)).ToString());*/
        obj1.tag = "1";
        obj2.tag = "2";
        obj3.tag = "3";
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
    }

    private void Update()
    {
        /*Debug.Log(RandomSpawn.nApple);
        texto_0.text = con.enletras(RandomSpawn.nApple.ToString());
        texto_4.text = con.enletras(RandomSpawn.nApple.ToString());
        texto_5.text = con.enletras(RandomSpawn.nApple.ToString());*/

        
        if (respuestaCorrecta == 1)
        {
            texto_1.text = con.enletras(RandomSpawn.nApple.ToString());
        }else if(respuestaCorrecta == 2)
        {
            texto_2.text = con.enletras(RandomSpawn.nApple.ToString());
        }else if (respuestaCorrecta == 3)
        {
            texto_3.text = con.enletras(RandomSpawn.nApple.ToString());
        }

        
    }

}
