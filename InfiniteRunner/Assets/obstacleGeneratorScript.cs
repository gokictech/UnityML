using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleGeneratorScript : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnDelay = 3f;
    private float lastSpawn;

    public GenerationMode mode;
    public List<GameObject> spawnedObstacles;

    public enum GenerationMode
    {
        random,
        seeded
    };

    void Start()
    {
        setGenerationMode();
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
        setGenerationMode();

    }

    //doesn't work yet, try reseeding every time an obstacle is spawned using an incremental seed
    private void setGenerationMode()
    {
        if(mode == GenerationMode.random)
        {
            Random.InitState(System.DateTime.Now.Millisecond);//random everytime, uses current time as a seed
        }
        else if(mode == GenerationMode.seeded)
        {
            Random.InitState(1);//Same obstacles everytime
        }
    }

}
