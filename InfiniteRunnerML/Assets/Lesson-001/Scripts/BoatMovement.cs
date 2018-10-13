using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOKiC.LessonPassOne
{
    public class BoatMovement : MonoBehaviour
    {

		//private new Rigidbody rigidbody;
        void Start()
        {
			//rigidbody = GetComponent<Rigidbody>();
        }

		public void Move(Vector3 direction, float speed)
		{
			transform.Translate(direction * speed);
		}
    }
}
