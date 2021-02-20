using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMovementNormal : MonoBehaviour
{
    public float speed = 5f;
    public float maxTurnDegreesPerFrame = 10f;
    public float verticalPosition = 0f;
    public float minMomentum = 0.2f;
    public bool canMove;

    private Rigidbody rb;
    private float horizontal;
    private float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        horizontal = 0f;
        vertical = 0f;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        if (!canMove)
            return;

        Vector3 v = new Vector3(horizontal * speed, 0f, vertical * speed);
        v += rb.position;
        v = new Vector3(v.x, verticalPosition, v.z);
        rb.position = v;

        if (ChangeRotation())
        {
            float y = CalculateDesiredRotation();
            rb.rotation = Quaternion.Euler(0f, y, 0f);
        }
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private bool ChangeRotation()
    {
        return Mathf.Abs(horizontal) > minMomentum || Mathf.Abs(vertical) > minMomentum;
    }

    private float CalculateDesiredRotation()
    {
        float y = Mathf.Rad2Deg * Mathf.Atan(horizontal / vertical);
        if (vertical < 0)
        {
            y += 180f;
        }
        else if (y < 0)
        {
            y += 360f;
        }
        return y;
    }
}
