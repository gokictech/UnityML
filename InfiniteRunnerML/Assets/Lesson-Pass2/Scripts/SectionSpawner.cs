using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOKiC
{
    public class SectionSpawner : MonoBehaviour
    {
        public River river;
        public Transform sectionObserver;
        public GameObject sectionPrefab;
        public int initialSize;
        public Vector3 offset;

        private Transform lastSection;

        private void Start()
        {
			if(OnStartErrorCheck() == false)
			{
				return;
			}

            Vector3 position = Vector3.zero;
            position += offset;

            for (int i = 0; i < initialSize; i++)
            {
                GameObject section = SpawnSection(position);
                lastSection = section.transform;
                position += offset;
            }

            transform.position = position;
        }

        private bool OnStartErrorCheck()
        {
            if (sectionObserver == null)
            {
                Debug.LogError("SectionObserver is not set.");
                return false;
            }

            if (river == null)
            {
                Debug.LogError("River is not set.");
                return false;
            }

            if (sectionPrefab == null)
            {
                Debug.LogError("SectionPrefab is not set");
                return false;
            }

			return true;
        }

        private void Update()
        {
            if (Physics.CheckSphere(sectionObserver.position, 1f) == false)
            {
                GameObject section = SpawnSection(lastSection.position + offset);
                lastSection = section.transform;
            }
        }

        private GameObject SpawnSection(Vector3 position)
        {
            GameObject section = Instantiate(sectionPrefab, position, Quaternion.identity);
            river.Add(section);

            return section;
        }
    }
}