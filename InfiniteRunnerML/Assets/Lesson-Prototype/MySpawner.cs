using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My
{

    public class MySpawner : MonoBehaviour
    {
        public MyRiver river;
        public GameObject spawnObject;
        public Transform[] spawnPoints;
        public float spawnInSeconds;
        private float spawnTimer;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (spawnTimer <= 0)
            {
                spawnTimer = spawnInSeconds;
                Spawn();
            }

            spawnTimer -= Time.deltaTime;
        }

        private void Spawn()
        {
            Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];

            var obj = Instantiate(spawnObject, point.position, Quaternion.identity);

            if (river == null)
            {
                river = GetComponent<MyRiver>();
            }

            river.Add(obj);
        }
    }

}