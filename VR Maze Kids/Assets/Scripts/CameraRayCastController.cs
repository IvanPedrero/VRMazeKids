using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                if (objectHit.gameObject.tag == "SceneChanger")
                {
                    SceneManager.LoadScene(1);
                }
                else
                {
                    // Change to red color.
                    objectHit.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                }

            }
        }
    }
}
