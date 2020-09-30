using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CameraRayCastController3 : MonoBehaviour
{
    private string value;
    private int res, res2, puntos, wrong;
    public static int score, wrongAnswer, neg, neg2, i = 0;
    public GameObject chest1, chest2, chest3;
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

                if (objectHit.gameObject.name == "gem" && objectHit.gameObject.GetComponent<MeshRenderer>().material.color != Color.blue)
                {
                    objectHit.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                    value = objectHit.gameObject.GetComponentInChildren<TextMesh>().text;
                    //objectHit.gameObject.name = "h";
                    //Debug.Log(value);
                }

                if (objectHit.gameObject.name == "Chest")
                {
                    //res = ivalue);
                    //res2 = int.Parse(objectHit.gameObject.GetComponentInChildren<TextMesh>().text);
                    objectHit.gameObject.GetComponentInChildren<TextMesh>().text = value;

                }
                if (objectHit.gameObject.name == "duck")
                {
                    GemsNumber.num[0] = int.Parse(chest1.GetComponentInChildren<TextMesh>().text);
                    GemsNumber.num[1] = int.Parse(chest2.GetComponentInChildren<TextMesh>().text);
                    GemsNumber.num[2] = int.Parse(chest3.GetComponentInChildren<TextMesh>().text);

                    for (i = 0; i < 3; i++)
                    {
                        if (GemsNumber.num[i] != GemsNumber.numOrd[i])
                        {

                            neg++;
                        }
                        else
                        {
                            neg2++;
                        }
                        /*if(GemsNumber.num[2] != 0)
                        {
                            for(i = 0; i<3; i++)
                            {
                                GemsNumber.num[i] = 0;
                            }
                        }*/
                    }
                    if (neg != 0)
                    {
                        SceneManager.LoadScene(3);
                        score = 0;
                        wrongAnswer++;
                        neg = 0;
                    }
                    else if (neg2 == 3)
                    {
                        score++;
                        wrongAnswer = 0;
                        neg2 = 0;
                        SceneManager.LoadScene(3);

                    }

                }




                /*if (objectHit.gameObject.tag == "1" && objectHit.gameObject.name == "gem")
                {
                    Destroy(hit.transform.gameObject);

                    if (objectHit.gameObject.tag != "1")
                    {
                        score = 0;
                        SceneManager.LoadScene(3);
                    }
                }
                if (objectHit.gameObject.tag == "2" && objectHit.gameObject.name == "gem")
                {
                    Destroy(hit.transform.gameObject);

                    if (objectHit.gameObject.tag == "2")
                    {
                        if (wrongAnswer != 0)
                        {
                            wrongAnswer = 0;
                        }

                    }
                    else
                    {
                        score = 0;
                        SceneManager.LoadScene(3);
                    }
                }
                if (objectHit.gameObject.tag == "3" && objectHit.gameObject.name == "gem")
                {
                    Destroy(hit.transform.gameObject);

                    if (objectHit.gameObject.tag == "3")
                    {
                        if (wrongAnswer != 0)
                        {
                            wrongAnswer = 0;
                        }
                        score++;
                        StartCoroutine(reloadScreen());
                    }
                    else
                    {
                        score = 0;
                        SceneManager.LoadScene(3);
                    }
                }*/


            }
        }
    }

    public IEnumerator reloadScreen()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(3);
    }

}
