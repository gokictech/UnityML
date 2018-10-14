using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOKiC
{
    public class River : MonoBehaviour
    {
        public Transform container;
        public Vector3 riverSpeed;
        public bool addVelocityOnStart;

		public Transform endOfRiverObserver;

		private List<Transform> riverObjects;

        void Start()
        {
            if (container == null)
            {
                Debug.LogError("River container is not set");
                return;
            }

            if (addVelocityOnStart)
            {
                foreach (Transform obj in container)
                {
                    Add(obj.gameObject);
                }
            }

        }

		void Update()
		{
			RemoveAtEndOfRiver();
		}

        public void Add(GameObject obj)
        {
            if (obj == null)
            {
                Debug.LogError("Trying to add empty game object to river");
                return;
            }

            obj.transform.SetParent(container);
            Rigidbody rb = obj.GetComponent<Rigidbody>();

            if (rb == null)
            {
                Debug.LogErrorFormat("No Rigidbody found in [{0}] while adding to river", obj.name);
                return;
            }

            SetVelocity(rb);

			if(riverObjects == null)
			{
				riverObjects = new List<Transform>();
			}

			riverObjects.Add(obj.transform);

        }

        private void SetVelocity(Rigidbody rb)
        {
            rb.velocity = riverSpeed;
        }

		private void RemoveAtEndOfRiver()
		{
			int count = riverObjects.Count;

			for(int i = count -1; i >=0 ; i--)
			{                
				if(riverObjects[i] != null && riverObjects[i].position.z > endOfRiverObserver.position.z)
				{
					Transform t  = riverObjects[i];
					riverObjects.RemoveAt(i);
					Destroy(t.gameObject);
				}
			}
		}
    }
}