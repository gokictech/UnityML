using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOKiC
{
    public class RemoveEnvironmentSection : MonoBehaviour
    {
		EnvironmentMover environmentMover;

        // Use this for initialization
        void Start()
        {
			environmentMover = GameObject.FindObjectOfType<EnvironmentMover>();
        }

        void OnTriggerEnter(Collider other)
        {
			Debug.Log("Collided with : " + other.gameObject.name);
			
			var section = other.gameObject.GetComponentInParent<Section>();

			if(section)
			{
				Debug.Log("Removed section :" + other.transform.parent.gameObject.name);
				Destroy(other.transform.parent.gameObject);
				environmentMover.UpdateListOfMoveObjects();
			}

        }
    }
}
