using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOKiC
{
	public class Sensor : MonoBehaviour 
	{
		[SerializeField]
		private bool draw = true;//Draw the raycasts (in editor view)
		
		[SerializeField]
		private float maxDist;

		public IEnumerable<float> GetDistancesAtAngle(float[] angles)
		{
			List<float> result = new List<float>();

			RaycastHit hit;

			foreach (float theta in angles)
			{
				float radians = theta * (Mathf.PI/ 180); 

				Vector3 dir = new Vector3(Mathf.Cos(radians), 0f, Mathf.Sin(radians));
				Physics.Raycast(transform.position, dir, out hit, maxDist);

				if(hit.collider)//if a collider was hit
				{
					result.Add(hit.distance);
					if (draw)
					{
						Debug.DrawRay(transform.position, dir * maxDist, Color.red, 0.05f);
					}
				}
				else//othewise add maxdist (instead of 0)
				{
					result.Add(maxDist);
					if (draw)
					{
						Debug.DrawRay(transform.position, dir * maxDist, Color.blue, 0.05f);
					}
				}


			}

			return result;
		}

		public void SetMaxDistance(float maxDistance)
		{
			this.maxDist = maxDistance;
		}

		public float GetMaxDistance()
		{
			return maxDist;
		}
	}
}
