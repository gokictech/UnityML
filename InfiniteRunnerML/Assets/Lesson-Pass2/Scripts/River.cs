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
        }

        private void SetVelocity(Rigidbody rb)
        {
            rb.velocity = riverSpeed;
        }
    }
}