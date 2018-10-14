using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {

    public string boatName = "Boat";
	public Transform initialPosition;
    
    void Start()
	{
		if(initialPosition == null)
		{
			Debug.LogError("initialPosition is not set.");
			return;
		}
	}
	
    void Update()
	{
		timeAlive += Time.deltaTime;
		SinglePlayer_GameScore.Instance.SetScore(boatName, (int)(timeAlive * (trashCollected == 0 ? 1 :trashCollected)));
	}
	
    void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
		{
			Debug.Log("hit an obstacle");
			Destroy(other.gameObject);
			Reset();
			return;
		}
		if(other.gameObject.layer == LayerMask.NameToLayer("Trash"))
		{
			Debug.Log("hit trash");
			Destroy(other.gameObject);
			trashCollected++;
			return;
		}
		Debug.Log("Collided with : " + other.gameObject.name);
		Reset();
	}
	
    private void Reset()
	{
		transform.position = initialPosition.position;
		timeAlive = 0f;
		trashCollected = 0;
	}
}