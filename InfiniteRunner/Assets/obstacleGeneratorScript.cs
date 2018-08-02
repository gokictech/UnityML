using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleGeneratorScript : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnDelay = 3f;
    private float lastSpawn;

    public List<GameObject> spawnedObstacles;

    void Start()
    {
        lastSpawn = Time.time;
        spawnedObstacles = new List<GameObject>();
    }

    void FixedUpdate()
    {
        if(Time.time > lastSpawn + spawnDelay)
        {
            lastSpawn = Time.time;
            float random = Random.Range(-3.75f, 3.75f);
            Vector3 offset = Vector3.zero;
            offset.x = random;

            GameObject newObs = Instantiate(obstacle, transform.position + offset, Quaternion.identity);
            spawnedObstacles.Add(newObs);
        }
    }

    public void resetObstacles()
    {
        lastSpawn = Time.time;
        foreach(GameObject obs in spawnedObstacles)
        {
            Destroy(obs);
        }
        spawnedObstacles.Clear();
    }

}
