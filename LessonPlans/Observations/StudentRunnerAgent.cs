using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class RunnerAgent : Agent
{

    public float speed = 5f;
    public const float MAX_OBS_DIST = 20F;
    public ObstacleManager manager;//refrence to obstacle manager

    private Vector3 startPos;
    private Rigidbody rb;
    private bool nearby = false;


    void Start()
    {
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
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////// Write your code below! /////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //We use AddVectorObs to send information to our neural network, the line below
        //tells our agent the distance to the nearest obstacle to its left
        AddVectorObs(distInDir(Vector3.left));

        //We can use Vector.<direction> to get a vector pointing in that direction, for example above we use Vector3.left
        //to check to the left from our agent 

        //1. Try copying the line above, instead using Vector3.right to check to the right of our agent instead!



        //Here are several other observations that check in other directions, such as forward, or diagonally from our agent
        //left left forward
        AddVectorObs(distInDir(Vector3.forward + Vector3.left + Vector3.left));
        //left forward
        AddVectorObs(distInDir(Vector3.left + Vector3.forward));
        //left forward forward
        AddVectorObs(distInDir(Vector3.left + Vector3.forward + Vector3.forward));
        //right forward forward
        AddVectorObs(distInDir(Vector3.right + Vector3.forward + Vector3.forward));
        //right right forward
        AddVectorObs(distInDir(Vector3.right + Vector3.right + Vector3.forward));


        //This observation tells us how fast the agent is moving, and in what direction
        AddVectorObs(rb.velocity.x / speed);


        //Here are a few more observations, keep the ones you think are important, and delete the lines you think are extra information!
        //2.
        AddVectorObs(distInDir(Vector3.forward));//forward

        //3. 
        AddVectorObs(System.DateTime.Now.Second);//How many seconds have passed since the day started

        //4. 
        AddVectorObs(distInDir(Vector3.right + Vector3.forward));//right forward

        //5. 
        AddVectorObs(Color.blue);// My favorite color is blue!


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////// End of activity ////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        Collider[] collisions = Physics.OverlapSphere(transform.position, 0.75f, LayerMask.GetMask("Obstacle"));
        if (collisions.Length > 0)
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


        if (nearby)
        {
            AddReward(-0.01f);
        }

        nearby = false;

        //used vectorAction to apply force
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = vectorAction[0];
        rb.AddForce(controlSignal * speed);

    }

    //shorcut method, gets the distance in a direction up to MAX_OBS_DIST
    private float distInDir(Vector3 dir)
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, dir, out hit, MAX_OBS_DIST);
        if (hit.distance > 0 && hit.distance < 2.5f)
        {
            nearby = true;
        }

        return normalizedDistance(hit);


    }

    //normalizes raycast hit distance between 0 and 1
    private float normalizedDistance(RaycastHit hit)
    {
        if (hit.collider)
        {
            return hit.distance / MAX_OBS_DIST;
        }
        else
        {
            return 1f;
        }
    }
}
