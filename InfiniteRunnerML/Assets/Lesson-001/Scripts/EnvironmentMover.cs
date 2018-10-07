using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMover : MonoBehaviour 
{
	public float speed = 0.3f;
	Transform[] objectsToMove;
	int childCount;
	
	void Start ()
	{
		
	}

	void Update()
	{
		foreach(Transform obj in objectsToMove)
		{
			Move(obj);
		}
	}

	public void UpdateListOfMoveObjects()
	{
		childCount = transform.childCount;
		
		objectsToMove = new Transform[childCount];
		for(int i = 0; i< childCount; i++)
		{
			objectsToMove[i] = transform.GetChild(i);
		}
	}
	
	public void Move(Transform objectToMove)
	{
		objectToMove.Translate(new Vector3(0f, 0f, speed));
	}
}
