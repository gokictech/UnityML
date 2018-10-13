using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOKiC.LessonPassOne
{
	public class BaseSensor : MonoBehaviour 
	{
		[SerializeField]
		private bool draw = true;//Draw the raycasts (in editor view)
		
		[SerializeField]
		protected float maxDist;

		public float[] GetDistancesAtAngle(float[] angles)
		{
			List<float> result = new List<float>();

			RaycastHit hit;


			foreach (float theta in angles)
			{
				float radians = theta * (Mathf.PI/ 180); 

				Vector3 dir = new Vector3(Mathf.Cos(radians), 0f, Mathf.Sin(radians)); // + transform.forward;
				Physics.Raycast(transform.position, dir, out hit, maxDist);

				if(hit.collider)//if a collider was hit
				{
					result.Add(hit.distance);
					if (draw)
					{
						//Debug.DrawRay(transform.position, hit.point, Color.red, 0.05f);
						Debug.DrawLine(transform.position, hit.point, Color.red);
					}
				}
				else//othewise add maxdist (instead of 0)
				{
					result.Add(maxDist);
					if (draw)
					{
						Debug.DrawRay(transform.position, dir * maxDist, Color.blue);
					}
				}


			}

			return result.ToArray();
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
