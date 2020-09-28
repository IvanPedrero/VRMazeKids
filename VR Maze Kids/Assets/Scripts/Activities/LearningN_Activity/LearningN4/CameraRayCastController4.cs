using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class CameraRayCastController4 : MonoBehaviour
{
    public static int score, wrongAnswer;
    private string NCorrecto;
    private int RCorrecta;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            // Hit something...
            if (Physics.Raycast(ray, out hit))
            {

                Transform objectHit = hit.transform;

                if (objectHit.gameObject.tag == "1" || objectHit.gameObject.tag == "2" || objectHit.gameObject.tag == "3" || objectHit.gameObject.tag == "4" || objectHit.gameObject.tag == "5")
                {
                    objectHit.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;

                    NCorrecto = NCorrecto + objectHit.gameObject.GetComponentInChildren<TextMesh>().text;
                    //Debug.Log(Ncorrecto);
                }

                if (objectHit.gameObject.tag == "Niño")
                {
                    RCorrecta = int.Parse(NCorrecto);
                    if (RCorrecta == BalloonsNumbers.respuesta)
                    {
                        if (wrongAnswer != 0)
                        {
                            wrongAnswer = 0;
                        }
                        score++;
                        Debug.Log(score);
                        StartCoroutine(reloadScreen());
                    }
                    else
                    {
                        if (score != 0)
                        {
                            score = 0;
                        }
                        wrongAnswer++;
                        Debug.Log(score);
                        StartCoroutine(reloadScreen());
                    }
                }
            }
        }
    }

    public IEnumerator reloadScreen()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(4);
    }

}
