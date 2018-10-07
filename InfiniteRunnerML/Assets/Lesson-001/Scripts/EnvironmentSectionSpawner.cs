using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOKiC
{
    public class EnvironmentSectionSpawner : MonoBehaviour
    {
        public GameObject sectionPrefab;
        public Vector3 offsetPosition;

        public int numberToSpawn;

        public bool startFromZero = true;

        void Start()
        {
            Vector3 startPosition = Vector3.zero;
            for (int i = 0; i < numberToSpawn; i++)
            {
                startPosition = offsetPosition * (i);
                if (startFromZero == false)
                {
                    startPosition += offsetPosition;
                }
                Instantiate(sectionPrefab, offsetPosition * (i + 1), Quaternion.identity, transform);
            }

            var mover = GameObject.FindObjectOfType<EnvironmentMover>();

            mover.UpdateListOfMoveObjects();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
