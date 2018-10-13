using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRiver : MonoBehaviour {

	public Vector3 riverSpeed;

	public float timeScale = 1f;
	private float lastTimeScale;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(lastTimeScale != timeScale)
		{
			lastTimeScale = timeScale;
			Time.timeScale = timeScale;
		}
	}

	public void Add(GameObject obj)
	{
		if(obj == null)
			return;
		
		obj.transform.SetParent(transform);


		var rb = obj.GetComponent<Rigidbody>();

		if(rb == null)
		{
			Debug.Log("No rigidbody on " + obj.name);
			return;
		}

		AddVelocity(rb);
	}

	private void AddVelocity(Rigidbody rb)
	{
		rb.velocity = riverSpeed;
		Debug.Log("["+rb.gameObject.name+"] : Add " + riverSpeed + " | " + rb.velocity);
	}
}
