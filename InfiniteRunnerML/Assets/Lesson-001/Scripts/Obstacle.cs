using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOKiC
{
    public class Obstacle : MonoBehaviour
    {
		public void OnCollisionEnter(Collision other)
        {
			//Debug.Log("Obstacle Hit : " + other.gameObject.name);

			Boat boat = other.gameObject.GetComponent<Boat>();

			if(boat != null)
			{
				//Debug.Log("Hit boat!");
				boat.HitObstacle(this);
			}
        }
    }
}
