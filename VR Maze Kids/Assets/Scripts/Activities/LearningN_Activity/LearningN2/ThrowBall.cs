using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThrowBall : MonoBehaviour
{
    public float throwForceInX = 0;
    public float throwForceInY = 28f;
    public float throwForceInZ = 5f;

    public Rigidbody ballRigidBody;

    public bool hasTouchGround, hasBeenThrown;

    //public GameObject obj1, obj2, obj3;


    float timeInterval;

    // Use this for initialization
    void Start()
    {
        hasBeenThrown = false;
        hasTouchGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !hasBeenThrown){
            RaycastHit hit;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                if (objectHit.gameObject.tag == "goodAns")
                {
                    ThrowRigidbodyBall();
                }
            }
        }
    }

    void ThrowRigidbodyBall()
    {
        hasBeenThrown = true;
        hasTouchGround = false;

        ballRigidBody.isKinematic = false;

        ballRigidBody.AddForce(throwForceInX, throwForceInY, throwForceInZ );
    }

    void ReturnBall()
    {
        SceneManager.LoadScene(2);
        /*ballRigidBody.isKinematic = true;
        transform.localPosition = new Vector3(-0.386f, 0.502f, 0.001f);
        transform.localRotation = Quaternion.identity;
        ballRigidBody.velocity = Vector3.zero;

        hasBeenThrown = false;
        hasTouchGround = false;*/

    }


    void OnCollisionEnter(Collision collision)
    {
        if (!hasTouchGround && hasBeenThrown)
        {
            hasTouchGround = true;
            Invoke("ReturnBall", 2);
        }
    }
}
