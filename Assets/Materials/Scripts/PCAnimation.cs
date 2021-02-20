using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCAnimation : MonoBehaviour
{
    public Animator animator;
    public PCMovementNormal pc;

    private float horizontal;
    private float vertical;
    private bool isWalking;

    void Start()
    {
        horizontal = 0f;
        vertical = 0f;
        isWalking = false;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        StartCoroutine(Animations());
    }

    /*
     * IEnumerator: Animations
     * Is called once per frame from Update- function. Checks if the spacebar is
     * pressed and if the object is moving and sets animations triggers and bools
     * accordingly.
     */

    IEnumerator Animations()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pc.canMove = false;
            animator.SetTrigger("Spacebar");
            yield return new WaitForSeconds(1);
            pc.canMove = true;
        }
        if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
