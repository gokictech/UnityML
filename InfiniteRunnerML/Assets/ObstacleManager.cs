using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {

    public GameObject obstacle;//refrence to obstacle prefab
    public float delay = 4f;
    private float lastSpawn;
    private List<GameObject> spawnedObstacles;

	void Start ()
    {
        spawnedObstacles = new List<GameObject>();
        lastSpawn = 0f;
	}
	
	void Update ()
    {
        //after the delay, spawn a new obstacle
        if(Time.time > lastSpawn + delay)
        {
            //range that ensures anywhere in the lane can contain obstacles
            Vector3 offset = new Vector3(Random.Range(-3.75f, 3.75f), 0f);
            GameObject newObs = Instantiate(obstacle, transform.position + offset, Quaternion.identity);
            spawnedObstacles.Add(newObs);
            lastSpawn = Time.time;
        }	
	}

    //destroy all the obstacles and clear the list
    public void resetObstacles()
    {
        foreach(GameObject obs in spawnedObstacles)
        {
            Destroy(obs);   
        }

        spawnedObstacles.Clear();
    }
}
