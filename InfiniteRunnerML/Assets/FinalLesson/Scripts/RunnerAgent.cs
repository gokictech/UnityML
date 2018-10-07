using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class RunnerAgent : Agent {

    public const float MAX_OBS_DIST = 10F;

    //refrence to obstacle manager
    public ObstacleManager manager;

    private Vector3 startPos;
    private bool nearby = false;
    public float nearbyDistance = 1.5f;

    private Sensor mySensor;
    private RunnerMovement movement;


    void Start ()
    {
        mySensor = gameObject.GetComponent<Sensor>();
        startPos = transform.position;
        //rb = gameObject.GetComponent<Rigidbody>();
        movement = GetComponent<RunnerMovement>();
	}

    public override void AgentReset()
    {
        //reset runner's position and velocity as well as obstacles
        movement.Reset();
        manager.resetObstacles();
        nearby = false;
    }

    public override void CollectObservations()
    {

        //use sensor to get distances
        List<float> distances = mySensor.getDistancesAtAngles(new float[] { 0f, 18, 36, 54, 72, 90, 108, 126, 144, 162, 180 }, MAX_OBS_DIST);
        foreach(float d in distances)
        {
            AddVectorObs(d / MAX_OBS_DIST);//normalize and add observation

            if(d < nearbyDistance)//if we're close to an obstacle
            {
                nearby = true;//we use this later for rewards
            }
        }

        //AddVectorObs(rb.velocity.x / speed);
        float velocityObservation = movement.SideWayVelocity() / movement.SideWayMaxVelocity();
        AddVectorObs(velocityObservation);

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
            movement.MoveLeft();
        }
        else if (vectorAction[0] > 0)
        {
            movement.MoveRight();
        }
       
    }

   
}
