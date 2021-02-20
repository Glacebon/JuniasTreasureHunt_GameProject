using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Rigidbody playerRB = null;
	public float downLimit = -690f;
	public float upLimit = 960f;
	public float leftLimit = -470f;
	public float rightLimit = 480f;

    void LateUpdate ()
    {
    	float y = transform.position.y;
    	float x = playerRB.position.x;
    	float z = playerRB.position.z;
    	x = Mathf.Clamp (x, leftLimit, rightLimit);
    	z = Mathf.Clamp (z, downLimit, upLimit);
    	transform.position = new Vector3 (x, y, z);
    }
}