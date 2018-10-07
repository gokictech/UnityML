﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOKiC
{
    public class EnvironmentSectionSpawner : MonoBehaviour
    {
        public GameObject sectionPrefab;
        public Vector3 offsetPosition;
		public Transform environment;

		public Transform newSectionTrigger;

        private EnvironmentMover environmentMover;

        public int numberToSpawn;

        public bool startFromZero = true;

        void Start()
        {
			CreateInitialSections();
            environmentMover = GameObject.FindObjectOfType<EnvironmentMover>();
        }

		private void CreateInitialSections()
		{
			Vector3 startPosition = Vector3.zero;
            for (int i = 0; i < numberToSpawn; i++)
            {
                startPosition = offsetPosition * (i);
                if (startFromZero == false)
                {
                    startPosition += offsetPosition;
                }
				
                Instantiate(sectionPrefab, offsetPosition * (i + 1), Quaternion.identity, environment);
            }

            var mover = GameObject.FindObjectOfType<EnvironmentMover>();

            mover.UpdateListOfMoveObjects();
		}


        private void Update()
        {
            if (Physics.CheckSphere(newSectionTrigger.position, 1) == false)
            {
                SpawnSection();
            }
        }

        private void SpawnSection()
        {
            Debug.Log("Spawn Section");
            Vector3 position = newSectionTrigger.position;
            position.x = 0;
            position.z = -30;
            Instantiate(sectionPrefab, position, Quaternion.identity, environment);

            environmentMover.UpdateListOfMoveObjects();
        }
    }
}
