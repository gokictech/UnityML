using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMovement : MonoBehaviour 
{
	public float speed = 5f;
	public float maxSpeed;
	public Transform startPosition;
	private new Rigidbody rigidbody;

	void Start () 
	{
		rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveLeft()
	{
		rigidbody.AddForce(new Vector3(-1,0,0) * speed);
	}

	public void MoveRight()
	{
		rigidbody.AddForce(new Vector3(1,0,0) * speed);
	}

	public float SideWayVelocity()
	{
		return rigidbody.velocity.x;
	}

	public float SideWayMaxVelocity()
	{
		return maxSpeed;
	}

	public void Reset()
	{
		 //reset position and velocity
        transform.position = startPosition.position;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
	}
}
