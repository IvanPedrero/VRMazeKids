using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class CameraRayCastController4 : MonoBehaviour
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

                Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.green);

                Transform objectHit = hit.transform;

                // Check if object layer is UI.
                if (objectHit.gameObject.layer == LayerMask.NameToLayer("Buttons"))
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

                if ((objectHit.gameObject.tag == "1" || objectHit.gameObject.tag == "2" || objectHit.gameObject.tag == "3" || objectHit.gameObject.tag == "4" || objectHit.gameObject.tag == "5") && objectHit.gameObject.GetComponent<MeshRenderer>().material.color != Color.blue)
                {
                    objectHit.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                    LearningNumbersN4Controller.NCorrecto = LearningNumbersN4Controller.NCorrecto + objectHit.gameObject.GetComponentInChildren<TextMesh>().text;
                    Debug.Log(LearningNumbersN4Controller.NCorrecto);
                }

                if (objectHit.gameObject.tag == "Niño")
                {
                    LearningNumbersN4Controller g = FindObjectOfType<LearningNumbersN4Controller>();
                    g.SendMessage("fin");
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
