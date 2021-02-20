using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCSlide : MonoBehaviour
{

    public float thrustSpeed;
    public float turnSpeed;
    /*public Animator animator;*/

    private float thrustInput;
    private float turnInput;
    private Rigidbody shipRigidBody;

    void Start()
    {
        shipRigidBody = GetComponent<Rigidbody>();
        /*animator = GetComponent<Animator>();*/
    }

    void Update()
    {
        thrustInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        shipRigidBody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);
        shipRigidBody.AddRelativeForce(0f, 0f, thrustInput * thrustSpeed);
        /*if (thrustInput != 0 || turnInput > 0.1)
        {
            animator.SetBool("isWalking", true);
        }
        else if (thrustInput == 0 || turnInput < 0.1)
        {
            animator.SetBool("isWalking", false);
        }*/
    }
}