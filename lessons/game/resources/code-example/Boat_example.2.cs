using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {

    public Transform initialPosition;

	public float timeAlive;

    void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Rock")
		{
			Debug.Log("hit a rock");
			Destroy(other.gameObject);
			Reset();
			return;
		}

		Debug.Log("Collided with : " + other.gameObject.name);
		Reset();
	}

	private void Update()
	{
		timeAlive += Time.deltaTime;
	}
	
    public void Reset()
	{
		timeAlive = 0;
		transform.position = initialPosition.position;
	}
}