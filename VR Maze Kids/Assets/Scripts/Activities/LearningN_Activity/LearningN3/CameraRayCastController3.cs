using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CameraRayCastController3 : MonoBehaviour
{
    public static int score, wrongAnswer;
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
                if (objectHit.gameObject.tag == "1" && objectHit.gameObject.name == "gem")
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
                }


            }
        }
    }

    public IEnumerator reloadScreen()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(3);
    }

}
