using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorRotator : MonoBehaviour 
{
	public float rotationSpeed = 360;

	public float rotationAngle = 90;

	private Vector3 rot;

	private int rotationDirection = 1;

	private bool showDebugLine;

	Vector3 startRotation;
	private void Start()
	{
		startRotation = transform.rotation.eulerAngles;

		startRotation.y -= rotationAngle/2;
	}


	void Update () 
	{

		transform.RotateAround(transform.position, Vector3.up, rotationDirection*rotationSpeed*Time.deltaTime);
		
		// this code change will rotate at rotations per second
		//transform.RotateAround(transform.position, Vector3.up, rotationDirection*rotationsPerSecond*360*Time.deltaTime);

		rot = transform.rotation.eulerAngles - startRotation;
		if(rot.y > rotationAngle)
		{
			rotationDirection = -1;
		}
		else if (rot.y <= 1)
		{
			rotationDirection = 1;
		}

		if(showDebugLine) Debug.Log("Rotation Y: " + rot.y.ToString("F0"));
	}
}
