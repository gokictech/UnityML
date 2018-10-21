using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	public River river;
	public GameObject spawnPrefab;
	public float spawnFrequency;
	public Transform spawnPositionContainer;
	
	private float spawnTimer;

	void Update()
	{
		spawnTimer -= Time.deltaTime;
		if(spawnTimer <= 0)
		{
			spawnTimer = spawnFrequency;
			int childNumber = Random.Range(0,spawnPositionContainer.childCount);
			Vector3 position = spawnPositionContainer.GetChild(childNumber).position;
			Spawn(position);
		}
	}

	private void Spawn(Vector3 position)
	{
		GameObject spawned = Instantiate(spawnPrefab, position, Quaternion.identity);
		river.Add(spawned);
	}
}