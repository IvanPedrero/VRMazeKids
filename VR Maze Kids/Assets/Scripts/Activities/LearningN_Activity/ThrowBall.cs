using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public float throwForceInX = 0;
    public float throwForceInY = 28f;
    public float throwForceInZ = 5f;

    public Rigidbody ballRigidBody;

    public bool hasTouchGround, hasBeenThrown;

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
            ThrowRigidbodyBall();
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
        ballRigidBody.isKinematic = true;
        transform.localPosition = new Vector3(-0.386f, 0.502f, 0.001f);
        transform.localRotation = Quaternion.identity;
        ballRigidBody.velocity = Vector3.zero;

        hasBeenThrown = false;
        hasTouchGround = false;

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
