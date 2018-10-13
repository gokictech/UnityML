using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOKiC.LessonPassOne
{

    public class SensorAngles : MonoBehaviour
    {
		public float[] angles;
		public float maxDistance;
		public bool draw = true;

		public void Start()
		{
			var offsetAngle = transform.rotation.eulerAngles.y;
			maxDistance = 5f;
			angles = new float[] { 0f, 18, 36, 54, 72, 90, 108, 126, 144, 162, 180 };
			for(int i = 0; i < angles.Length; i++)
			{
				angles[i] += offsetAngle;
			}
		}

        public List<float> getDistancesAtAngles()
        {
            List<float> result = new List<float>();

            RaycastHit hit;

            foreach (float theta in angles)
            {
                float radians = theta * (Mathf.PI / 180);

                Vector3 dir = new Vector3(Mathf.Cos(radians), 0f, Mathf.Sin(radians));
                Physics.Raycast(transform.position, dir, out hit, maxDistance);

                if (hit.collider)//if a collider was hit
                {
                    result.Add(hit.distance / maxDistance);
                    if (draw)
                    {
                        Debug.DrawRay(transform.position, dir * maxDistance, Color.red);
                    }
                }
                else//othewise add maxdist (instead of 0)
                {
                    result.Add(1); // == maxDistance / maxDistance
                    if (draw)
                    {
                        Debug.DrawRay(transform.position, dir * maxDistance, Color.blue);
                    }
                }


            }

            return result;
        }
    }
}
