using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleGeneratorScript : MonoBehaviour
{
    //Refrence to obstacle prefab
    public GameObject obstacle;
    //delay in seconds between each obstacle
    public float spawnDelay = 3f;
    //WIP, enum to determine how the obstacles will be randomly spawned
    public GenerationMode mode;
    //list of currently spawned obstacles so they can be deleted on reset
    public List<GameObject> spawnedObstacles;

    private float lastSpawn;

    //WIP:  random: different for every agent
    //      seeded: same for every agent
    public enum GenerationMode
    {
        random,
        seeded
    };

    //called when the play button is pressed
    void Start()
    {
        setGenerationMode();
        lastSpawn = Time.time;
        spawnedObstacles = new List<GameObject>();

        
    }

    //called every physics update
    void FixedUpdate()
    {
        //spawns the obstacle after delay
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

    //deletes all obstacles that have already been spawned, resets delay
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
