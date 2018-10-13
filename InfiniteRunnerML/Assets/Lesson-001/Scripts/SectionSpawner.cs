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

		public Transform newSectionObserver;

        private EnvironmentMover environmentMover;

        public int numberToSpawn;
        private Transform lastSection;

        void Start()
        {
			CreateInitialSections();
            environmentMover = gameObject.transform.parent.GetComponentInChildren<EnvironmentMover>();
        }

		public void CreateInitialSections()
		{
            var mover = GameObject.FindObjectOfType<EnvironmentMover>();

			Vector3 startPosition = Vector3.zero;
            for (int i = 0; i < numberToSpawn; i++)
            {
                transform.position += offsetPosition;
                //SpawnSection(transform.position);
                
                // this section is added later when we we add the obstacle and trash spawners
                var go = SpawnSection(transform.position);
                lastSection = go.transform; 
            }

            transform.position += offsetPosition;
            
            mover.UpdateListOfMoveObjects();
		}

        private void Update()
        {
            if(environmentMover.multiplier <= 0)
                return;

            if (Physics.CheckSphere(newSectionObserver.position, 1) == false)
            {
                if(lastSection == null)
                {
                    lastSection = transform;
                }

                var go = SpawnSection(lastSection.position + offsetPosition);
                lastSection = go.transform;
                environmentMover.UpdateListOfMoveObjects();
            }
        }

        private GameObject SpawnSection(Vector3 position)
        {
            //Debug.Log("Spawn Section");
                        
            var go = Instantiate(sectionPrefab, position, Quaternion.identity, environment);

            return go;
        }
    }
}
