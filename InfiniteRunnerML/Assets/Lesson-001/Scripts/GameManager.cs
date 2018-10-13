using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOKiC.LessonPassOne
{
    public class GameManager : MonoBehaviour
    {
        public float timeScale = 1;
        public float resetTime = 2f;
        public bool applyTimeScale = false;
        EnvironmentMover environment;
		SectionSpawner sectionSpawner;

        private float lastTimeScale;
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

        private void Update()
        {
            if(applyTimeScale == false)
                return;
                
            if(lastTimeScale != timeScale)
            {
                Time.timeScale = timeScale;
                lastTimeScale = timeScale;
            }
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

			environment.multiplier = environment.GetInitialMultiplier();
        }
    }
}
