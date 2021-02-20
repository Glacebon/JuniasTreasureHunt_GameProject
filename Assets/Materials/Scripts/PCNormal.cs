using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCNormal : MonoBehaviour
{
	public float speed = 5f;
	public float maxTurnDegreesPerFrame = 10f;
	public float verticalPosition = 0f;
	public float minMomentum = 0.2f;
    public float stopTime = 1f;

	private Rigidbody rb;
	private float horizontal;
	private float vertical;
    private float stoppedTill;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        horizontal = 0f;
        vertical = 0f;
        stoppedTill = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis ("Horizontal");
        vertical = Input.GetAxis ("Vertical");
    }

    void FixedUpdate()
    {
        if (IsStopped ())
            return;

    	Vector3 v = new Vector3 (horizontal * speed, 0f, vertical * speed);
    	v += rb.position;
    	v = new Vector3 (v.x, verticalPosition, v.z);
    	rb.position = v;

    	if (ChangeRotation ())
    	{
            // float y = CalculateRotation ();
            float y = CalculateDesiredRotation ();
	        rb.rotation = Quaternion.Euler (0f, y, 0f);
        }
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Debug.Log ($"current rotation = {rb.rotation.eulerAngles.y}");

        Vector3 p = rb.position;
        Quaternion r = rb.rotation;
        int px = Mathf.RoundToInt (p.x);
        int py = Mathf.RoundToInt (p.y);
        int pz = Mathf.RoundToInt (p.z);
        int rx = Mathf.RoundToInt (r.x);
        int ry = Mathf.RoundToInt (r.y);
        int rz = Mathf.RoundToInt (r.z);
        /*Debug.Log ($"position: ({px}, {py}, {pz})   rotation: ({rx}, {ry}, {rz})   v: {vertical} h: {horizontal}");*/
    }

    public bool IsWalking()
    {
        return (Mathf.Abs (horizontal) > 0.1f || Mathf.Abs (vertical) > 0.1f) && Time.time >= stoppedTill;
    }

    public bool IsStopped()
    {
        return Time.time < stoppedTill;
    }

    public void Stop()
    {
        stoppedTill = Time.time + stopTime;
    }

    private bool ChangeRotation ()
    {
        return Mathf.Abs (horizontal) > minMomentum || Mathf.Abs (vertical) > minMomentum;
    }

    private float CalculateDesiredRotation()
    {
    	float y = Mathf.Rad2Deg * Mathf.Atan (horizontal/vertical);
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

/*
    private float CalculateRotation()
    {
    	float desiredRotation = CalculateDesiredRotation();
        float currentRotation = rb.rotation.eulerAngles.y;

        Debug.Log ($"current rotation = {currentRotation}");

        float cw = currentRotation > desiredRotation ? currentRotation - 360f + desiredRotation : currentRotation + desiredRotation;
    	float ccw = currentRotation < desiredRotation ? currentRotation + 360f - desiredRotation : currentRotation - desiredRotation;
    	if (ccw < cw)
    	{
    	
    		// Debug.Log($"curRot={currentRotation}, desRot={desiredRotation}, cw={cw}, ccw={ccw}, dir=ccw, res={(ccw < maxTurnDegreesPerFrame ? desiredRotation : currentRotation - maxTurnDegreesPerFrame)}");

    		return ccw < maxTurnDegreesPerFrame ? desiredRotation : currentRotation - maxTurnDegreesPerFrame;
    	}

		// Debug.Log($"curRot={currentRotation}, desRot={desiredRotation}, cw={cw}, ccw={ccw}, dir=cw, res={(cw < maxTurnDegreesPerFrame ? desiredRotation : currentRotation + maxTurnDegreesPerFrame)}");

    	return cw < maxTurnDegreesPerFrame ? desiredRotation : currentRotation + maxTurnDegreesPerFrame;
    }
*/
}