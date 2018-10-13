using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBoatTest : MonoBehaviour {

	public float speed;
	float horizontal;
	new Rigidbody rigidbody;

	Vector3 HorizontalVector = new Vector3(0,0,1);

	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}
	// Update is called once per frame
	void Update () 
	{
		horizontal = Input.GetAxis("Horizontal");
	}

	void FixedUpdate()
	{
		//rigidbody.AddForce(HorizontalVector*speed*horizontal, ForceMode.Impulse);
		rigidbody.velocity = HorizontalVector*speed*horizontal;
	}

	void OnCollisionEnter(Collision other)
	{
		Destroy(other.gameObject);
	}
}
