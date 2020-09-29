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
                    LearningNumbersN1 g = FindObjectOfType<LearningNumbersN1>();
                    g.SendMessage("correctAnswers"); 


                }
                else if (objectHit.gameObject.tag == "wrongAns")
                {
                    // Change to red color.
                    objectHit.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                    LearningNumbersN1 g = FindObjectOfType<LearningNumbersN1>();
                    g.SendMessage("wrongAnswers");


                }

            }
        }
    }

}
