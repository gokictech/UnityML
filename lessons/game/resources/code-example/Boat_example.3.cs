using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {

    public Transform initialPosition;

	public float timeAlive;
	public int trashCollected;

    void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Rock")
		{
			Debug.Log("hit a rock");
			Destroy(other.gameObject);
			Reset();
			return;
		}

		if(other.gameObject.tag == "Trash")
		{
			Debug.Log("collected trash");
			Destroy(other.gameObject);
			trashCollected++;
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
		trashCollected = 0;
		transform.position = initialPosition.position;
	}
}