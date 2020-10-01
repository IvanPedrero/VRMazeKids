using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CameraRayCastController3 : MonoBehaviour
{
    private string value;
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

                if (objectHit.gameObject.name == "gem" && objectHit.gameObject.GetComponent<MeshRenderer>().material.color != Color.blue)
                {
                    objectHit.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                    value = objectHit.gameObject.GetComponentInChildren<TextMesh>().text;
                }

                if (objectHit.gameObject.name == "Chest")
                {
                    objectHit.gameObject.GetComponentInChildren<TextMesh>().text = value;

                }
                if (objectHit.gameObject.name == "duck")
                {
                    LearningNumbersN3Controller g = FindObjectOfType<LearningNumbersN3Controller>();
                    g.SendMessage("fin");
                }
            }
        }
    }
}
