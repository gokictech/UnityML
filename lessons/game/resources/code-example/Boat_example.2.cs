using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {

    public Transform initialPosition;

    void OnCollisionEnter(Collision other)
	{
		Debug.Log("Collided with : " + other.gameObject.name);
		Reset();
	}
	
    public void Reset()
	{
		transform.position = initialPosition.position;
	}
}