using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

namespace GOKiC.LessonPassOne
{
    public class AIBoatDriver : Agent
    {

        public float speed = 5f;
        public float nearbyDistance = 1.5f;
        private Vector3 rightDirection = new Vector3(-1, 0, 0);
        private Vector3 leftDirection = new Vector3(1, 0, 0);
        BoatMovement movement;
        Boat boat;
        ForwardSensor[] sensors;
        SensorAngles[] sensorAngles;

		[SerializeField]
        private bool nearby = false;

        private bool turnedOff;

        // Use this for initialization
        void Start()
        {
            movement = GetComponent<BoatMovement>();
            boat = GetComponent<Boat>();

            var _sensors = GetComponentsInChildren<ForwardSensor>();
            sensors = _sensors;

            sensorAngles = GetComponentsInChildren<SensorAngles>();

            turnedOff = false;


			// ./models/ppo\model-1000001.cptk
        }

        public override void CollectObservations()
        {
            // foreach(var s in sensors)
            // {
            // 	float distance = s.Sense();
            // 	if(distance >= 0)
            // 	{
            // 		AddVectorObs(distance);
            // 		if(distance < nearbyDistance)
            // 		{
            // 			nearby = true;
            // 		}
            // 	}
            // 	else
            // 	{
            // 		AddVectorObs(1);
            // 	}
            // }

            foreach (var sa in sensorAngles)
            {
                var distances = sa.getDistancesAtAngles();

                foreach (float d in distances)
                {
                    AddVectorObs(d);//normalize and add observation
                    if (d < nearbyDistance)//if we're close to an obstacle
                    {
                        nearby = true;//we use this later for rewards
                    }
                }
            }

            // if using Physics for sideways movement
            // add boat sideways velocity to observation
            //float velocityObservation = movement.SideWayVelocity() / movement.SideWayMaxVelocity();
            //AddVectorObs(velocityObservation);
        }

        public override void AgentAction(float[] vectorAction, string textAction)
        {
            // Collider[] collisions = Physics.OverlapSphere(transform.position, 0.75f, LayerMask.GetMask("Obstacle"));
            // if(collisions.Length > 0)
            // {
            // 	//the agent has hit an obstacle
            // 	Debug.Log("Agent has hit an obstacle!!!!!");
            // 	AddReward(-1f);
            // 	Done();//calls agent reset
            // }
            // else
            // {
            // 	//the agent has survided (for now)
            // 	AddReward(0.01f);
            // }

            if (turnedOff && boat.isAlive)
            {
                turnedOff = false;
            }

            if (turnedOff)
            {
                return;
            }

            if (!boat.isAlive)
            {
                AddReward(-1);
                //Debug.Log("Boat has hit something!");
                turnedOff = true;
                Done();
            }
            else // boat has survived (for now)
            {
                AddReward(0.1f);
            }

            //if we're getting close to an obstacle
            if (nearby)
            {
                AddReward(-0.01f);
            }

            nearby = false;

            //used vectorAction to apply force
            //Vector3 controlSignal = Vector3.zero;
            //controlSignal.x = vectorAction[0];//the control signal is the output returned by the neural network
            //rb.AddForce(controlSignal * speed);

            if (vectorAction[0] < 0)
            {
                movement.Move(leftDirection, speed * Time.deltaTime);
            }
            else if (vectorAction[0] > 0)
            {
                movement.Move(rightDirection, speed * Time.deltaTime);
            }
        }

        public override void AgentReset()
        {
            Debug.Log("Resetting agent");
            //reset runner's position and velocity as well as obstacles
            //movement.Reset();
            //manager.resetObstacles();
            nearby = false;
            boat.Reset();
        }
    }
}
