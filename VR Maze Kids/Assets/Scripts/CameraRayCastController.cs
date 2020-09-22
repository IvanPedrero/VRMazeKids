using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CameraRayCastController : MonoBehaviour
{
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
                if (objectHit.gameObject.tag == "goodAns")
                {
                    objectHit.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                    StartCoroutine(reloadScreen());
                    /*obj1.SetActive(false);
                    obj2.SetActive(true);
                    obj3.SetActive(false);
                    obj4.SetActive(true);
                    obj5.SetActive(false);
                    obj6.SetActive(true);*/
                }
                else if(objectHit.gameObject.tag == "1" || objectHit.gameObject.tag == "2" || objectHit.gameObject.tag == "3")
                {
                    // Change to red color.
                    objectHit.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                    StartCoroutine(reloadScreen());
                
                }

            }
        }
    }

    public IEnumerator reloadScreen()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }

}
