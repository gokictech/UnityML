using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOKiC
{
    public class GameManager : MonoBehaviour
    {
        public float resetTime = 2f;
        EnvironmentMover environment;
		SectionSpawner sectionSpawner;
        void Start()
        {
            environment = GetComponentInChildren<EnvironmentMover>();
			sectionSpawner = GetComponentInChildren<SectionSpawner>();
        }

        public void ResetGame()
        {
			Debug.Log("Resetting game");
            StartCoroutine(ResetEnvironment());
        }

        private IEnumerator ResetEnvironment()
        {
            var count = environment.transform.childCount;
            Transform[] objects = new Transform[count];

            float delay = resetTime / count;

            for (int i = 0; i < count; i++)
            {
                objects[i] = environment.transform.GetChild(count-i-1);
            }

			for (int i = 0; i < count; i++)
            {
				if(objects[i])
				{
	                Destroy(objects[i].gameObject);
					yield return new WaitForSeconds(delay);
				}
            }

			var position = sectionSpawner.transform.position;
			position.z = 0;

            position -= sectionSpawner.offsetPosition;
			sectionSpawner.transform.position = position;

			sectionSpawner.CreateInitialSections();

			environment.multiplier = 5;
        }
    }
}
