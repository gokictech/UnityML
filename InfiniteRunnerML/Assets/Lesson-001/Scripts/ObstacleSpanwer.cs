using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOKiC
{
    public class ObstacleSpanwer : MonoBehaviour
    {
		public GameObject obstaclePrefab;
        public float spawnFrequencyInSeconds = 3f;
        public bool turnOffMeshForStartPositions = false;
        private EnvironmentMover environment;
        private List<Transform> startPositions;
        private float spawnTimer;
		
        // Use this for initialization
        void Start()
        {
            var objs = gameObject.GetComponentsInChildren<SpawnStartPosition>();
            startPositions = new List<Transform>();
            foreach(SpawnStartPosition o in objs)
            {
                startPositions.Add(o.transform);

                if(turnOffMeshForStartPositions)
                {
                    o.gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
            }

            var env = GameObject.FindObjectOfType<EnvironmentMover>();
            environment = env;

            spawnTimer = spawnFrequencyInSeconds;
        }

        public void Update()
        {
            spawnTimer -= Time.deltaTime;
            if(spawnTimer <= 0)
            {
                SpawnObstacle();
                spawnTimer = spawnFrequencyInSeconds/environment.multiplier;
            }
        }


        public void SpawnObstacle()
        {
            Vector3 position = startPositions[Random.Range(0, startPositions.Count - 1)].position;
            Instantiate(obstaclePrefab, position, Quaternion.identity, environment.gameObject.transform);
            environment.UpdateListOfMoveObjects();
        }
    }
}
