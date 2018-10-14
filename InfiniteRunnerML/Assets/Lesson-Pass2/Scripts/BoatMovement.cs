using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOKiC
{
    public class BoatMovement : MonoBehaviour
    {
		private new Rigidbody rigidbody;

		private void Start()
		{
			rigidbody = GetComponent<Rigidbody>();
		}
		public void SetVelocity(Vector3 direction, float speed)
		{
			rigidbody.velocity = direction*speed;
		}
    }
}
