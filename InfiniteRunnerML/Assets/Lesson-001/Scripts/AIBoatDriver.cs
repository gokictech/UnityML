using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

namespace GOKiC
{
    public class AIBoatDriver : Agent
    {

		public float speed = 5f;
		public float nearbyDistance = 1.5f;
		private Vector3 rightDirection = new Vector3(-1,0,0);
		private Vector3 leftDirection = new Vector3(1,0,0);
		BoatMovement movement;
		ForwardSensor[] sensors;

		private bool nearby = false;

        // Use this for initialization
        void Start()
        {
			movement = GetComponent<BoatMovement>();

			var _sensors = GetComponentsInChildren<ForwardSensor>();
			sensors = _sensors;
        }

		public override void CollectObservations()
		{
			int count = 0;
			foreach(var s in sensors)
			{
				float distance = s.Sense();
				if(distance >= 0)
				{
					AddVectorObs(distance);
					count++;
					if(distance < nearbyDistance)
					{
						nearby = true;
					}
				}
				else
				{
					AddVectorObs(1);
					count++;
				}
			}

			// if using Physics for sideways movement
			// add boat sideways velocity to observation
			//float velocityObservation = movement.SideWayVelocity() / movement.SideWayMaxVelocity();
        	//AddVectorObs(velocityObservation);

			Debug.Log("Observations Received: " + count);
		}

		public override void AgentAction(float[] vectorAction, string textAction)
		{
			Collider[] collisions = Physics.OverlapSphere(transform.position, 0.75f, LayerMask.GetMask("Obstacle"));
			if(collisions.Length > 0)
			{
				//the agent has hit an obstacle
				AddReward(-1f);
				Done();//calls agent reset

			}
			else
			{
				//the agent has survided (for now)
				AddReward(0.01f);
			}
			
			//if we're getting close to an obstacle
			if(nearby)
			{
				AddReward(-0.01f);
			}

			nearby = false;

			//used vectorAction to apply force
			//Vector3 controlSignal = Vector3.zero;
			//controlSignal.x = vectorAction[0];//the control signal is the output returned by the neural network
			//rb.AddForce(controlSignal * speed);

			if(vectorAction[0] < 0)
			{
				movement.Move(leftDirection, speed*Time.deltaTime);
			}
			else if (vectorAction[0] > 0)
			{
				movement.Move(rightDirection, speed*Time.deltaTime);
			}
		}

		public override void AgentReset()
		{
			//reset runner's position and velocity as well as obstacles
			//movement.Reset();
			//manager.resetObstacles();
			nearby = false;
		}
    }
}
