using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class RunnerAgent : Agent
{
    //Max distance the agent will "see" with raycasts
    public const float MAX_OBS_DIST = 20f;
    //delay between intermitent larger rewards (TODO: fix timing, this number isn't exact for some reason)
    public float goalTime = 5.0f;
    //speed mutliplier for agent movements
    public float speed = 3f;
    //refrence to this agents obstacle generator, used for resets
    public obstacleGeneratorScript obstacleGenerator;

    //private variables
    private Rigidbody rb;
    private Vector3 startPos;
    private float elapsedTime;
    private float lastAction;

    //called when the play button is pressed in the editor
    private void Start()
    {
        lastAction = Time.time;
        rb = gameObject.GetComponent<Rigidbody>();
        elapsedTime = 0f;
        startPos = transform.position;
    }

    //called when the agent is marked Done();
    public override void AgentReset()
    {
        transform.position = startPos;
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        elapsedTime = 0f;
        obstacleGenerator.resetObstacles();
    }

    //Collects observations and sends them to the brain, similar to Update() or FixedUpdate() in function
    public override void CollectObservations()
    {
        //used to get info about what each raycast hit
        RaycastHit hit;
        //distances to walls
        Physics.Raycast(transform.position, Vector3.left, out hit, MAX_OBS_DIST, LayerMask.GetMask("Obstacle"));
        AddVectorObs(hit.distance / MAX_OBS_DIST);

        Physics.Raycast(transform.position, Vector3.right, out hit, MAX_OBS_DIST, LayerMask.GetMask("Obstacle"));
        AddVectorObs(hit.distance / MAX_OBS_DIST);
        //distance to obstacles
        for(float i = 0; i < Mathf.PI; i += 0.15f) //fan of raycasts from 0-PI (0-180deg), total: 3.1415/0.15 = 21
        {
            Vector3 direction = new Vector3(Mathf.Cos(i), 0, Mathf.Sin(i));

            Physics.Raycast(transform.position, direction, out hit, MAX_OBS_DIST, LayerMask.GetMask("Obstacle"));
            if(hit.collider)
            {
                AddVectorObs(hit.distance / MAX_OBS_DIST);
            } else
            {
                AddVectorObs(1f);//Raycasts that don't hit anything have a distance of 0, instead we pass the max value (normalized [0,1])
            }

        }
        
        //agent velocity
        AddVectorObs(rb.velocity.x / speed);
    }

    //Used to recieve output from the Brain, vectorAction contains the continuous outputs from the network
    public override void AgentAction(float[] vectorAction, string textAction)
    {
        elapsedTime += Time.time - lastAction;//time elapsed since last action
        lastAction = Time.time;

        //objects hitting the agent
        Collider[] obstacles = Physics.OverlapSphere(transform.position, 0.51f, LayerMask.GetMask("Obstacle"));
        bool hitObstacle = false;
        foreach(Collider c in obstacles)
        {
            Debug.Log("hit obstacle, distance:" + Vector3.Distance(transform.position, c.ClosestPoint(transform.position)));
            hitObstacle = true;
            AddReward(-1f);
            Done();//the agent hit an obstacle and failed
        }

        //reward every Update for not hitting anything
        if(!hitObstacle)
        {
            AddReward(0.01f);
        }

        if(elapsedTime >= goalTime)//periodic larger rewards
        {
            Debug.Log("1 reward added");
            AddReward(1);
            elapsedTime = 0;
        }

        //apply control signals to agent
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = vectorAction[0];
        rb.AddForce(controlSignal * speed);
    }


}
