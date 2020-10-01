using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class CameraRayCastController : MonoBehaviour
{
    public Transform navigatorPosition;

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

                // Check if object layer is UI.
                if(objectHit.gameObject.layer == LayerMask.NameToLayer("Buttons"))
                {
                    ButtonClickEvent b = objectHit.gameObject.GetComponent<ButtonClickEvent>();
                    b.RunControllerFunction();
                }

                // Navigation WITH MESSAGING.
                else if (objectHit.gameObject.layer == LayerMask.NameToLayer("NavigationButtons"))
                {
                    NavigationButtonClickEvent b = objectHit.gameObject.GetComponent<NavigationButtonClickEvent>();
                    b.DoAction();
                    return;
                }

                // Validate pause.
                if (PauseController.instance.isPause)
                {
                    return;
                }

                if (objectHit.gameObject.tag == "goodAns")
                {
                    // Enviar mensaje al controlador.
                    objectHit.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                    LearningNumbersN1Controller g = FindObjectOfType<LearningNumbersN1Controller>();
                    g.SendMessage("correctAnswers"); 


                }
                else if (objectHit.gameObject.tag == "wrongAns")
                {
                    // Change to red color.
                    objectHit.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                    LearningNumbersN1Controller g = FindObjectOfType<LearningNumbersN1Controller>();
                    g.SendMessage("wrongAnswers");


                }

            }
        }
    }

}
