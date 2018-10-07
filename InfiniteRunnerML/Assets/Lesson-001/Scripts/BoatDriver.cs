using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOKiC
{
	public class BoatDriver : MonoBehaviour 
	{
		public float speed = 5f;
		private Vector3 rightDirection = new Vector3(-1,0,0);
		private Vector3 leftDirection = new Vector3(1,0,0);
		BoatMovement movement;
		float horizontal;
		void Start () {
			movement = GetComponent<BoatMovement>();
		}
		
		void Update () 
		{
			horizontal = Input.GetAxis("Horizontal");
		}

		void FixedUpdate()
		{
			if(movement == null)
			{
				Debug.LogError("No BoatMovement found!");
			}

			if(horizontal < 0)
			{
				movement.Move(leftDirection, speed * Time.fixedDeltaTime);
			}
			else if(horizontal > 0)
			{
				movement.Move(rightDirection, speed * Time.fixedDeltaTime);
			}
		}
	}
}
