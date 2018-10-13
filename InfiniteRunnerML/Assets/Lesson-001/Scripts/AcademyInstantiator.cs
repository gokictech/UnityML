using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOKiC.LessonPassOne
{
    public class AcademyInstantiator : MonoBehaviour
    {
        public GameObject gameInstance;
        public int instancesToCreate = 5;
        public Vector3 offset = new Vector3(30, 0, 0);

        // Use this for initialization
        void Awake()
        {
            for (int i = 0; i < instancesToCreate; i++)
            {
                var go = Instantiate(gameInstance, Vector3.zero, Quaternion.identity);

                go.transform.position = offset * (i + 1);

				Boat boat = go.GetComponentInChildren<Boat>();
				boat.boatName = " Bot #"+i;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
