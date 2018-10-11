using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOKiC
{
    public class ForwardSensor : BaseSensor
    {
		private RaycastHit hit;
		public float Sense()
		{
			return SenseForward(); //GetDistancesAtAngle(forward)[0];
		}

		private float SenseForward()
		{
			if(Physics.Raycast(transform.position, transform.forward, out hit, maxDist) == false)
			{
				Debug.DrawLine(transform.position, transform.position + transform.forward*maxDist, Color.blue);
				return -1; // didn't hit anything
			}

			Debug.DrawLine(transform.position, hit.point, Color.red);
			var distance = Vector3.Distance(transform.position, hit.point) / maxDist;

			return distance;
		}
    }
}
