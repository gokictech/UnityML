using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class RunnerAgent : Agent {

    public float speed = 5f;
    public const float MAX_OBS_DIST = 10F;
    public ObstacleManager manager;//refrence to obstacle manager

    private Vector3 startPos;
    private Rigidbody rb;
    private bool nearby = false;
    public float nearbyDistance = 1.5f;

    private Sensor mySensor;


    void Start ()
    {
        mySensor = gameObject.GetComponent<Sensor>();
        startPos = transform.position;
        rb = gameObject.GetComponent<Rigidbody>();
	}

    public override void AgentReset()
    {
        //reset position and velocity as well as obstacles
        transform.position = startPos;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
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

        

        AddVectorObs(rb.velocity.x / speed);

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
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = vectorAction[0];
        rb.AddForce(controlSignal * speed);
       
    }

   
}
