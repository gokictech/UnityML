﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOKiC
{
    public class SectionSpawner : MonoBehaviour
    {
        public GameObject sectionPrefab;
        public Vector3 offsetPosition;
		public Transform environment;

		public Transform newSectionTrigger;

        private EnvironmentMover environmentMover;

        public int numberToSpawn;
        private Transform lastSection;

        void Start()
        {
			CreateInitialSections();
            environmentMover = GameObject.FindObjectOfType<EnvironmentMover>();
        }

		private void CreateInitialSections()
		{
			Vector3 startPosition = Vector3.zero;
            lastSection = transform;
            for (int i = 0; i < numberToSpawn; i++)
            {
                SpawnSection();
                transform.position += offsetPosition;
            }

            var mover = GameObject.FindObjectOfType<EnvironmentMover>();

            mover.UpdateListOfMoveObjects();
		}


        private void Update()
        {
            if (Physics.CheckSphere(newSectionTrigger.position, 1) == false)
            {
                SpawnSection();
                environmentMover.UpdateListOfMoveObjects();
            }
        }

        private void SpawnSection()
        {
            Debug.Log("Spawn Section");
            Vector3 position = lastSection.position;
            position += offsetPosition;
            
            var go = Instantiate(sectionPrefab, position, Quaternion.identity, environment);

            lastSection = go.transform;
        }
    }
}
