using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class RunnerAgent : Agent
{
    public const float MAX_OBS_DIST = 20f;
    public float goalTime = 5.0f;
    public float speed = 3f;
    public obstacleGeneratorScript obstacleGenerator;

    private Rigidbody rb;
    private Vector3 startPos;
    private float elapsedTime;
    private float lastAction;

    private void Start()
    {
        lastAction = Time.time;
        rb = gameObject.GetComponent<Rigidbody>();
        elapsedTime = 0f;
        startPos = transform.position;
    }

    public override void AgentReset()
    {
        transform.position = startPos;
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        elapsedTime = 0f;
        obstacleGenerator.resetObstacles();
    }

    public override void CollectObservations()
    {
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
                AddVectorObs(1f);
            }

        }
        
        //agent velocity
        AddVectorObs(rb.velocity.x / speed);
    }


    public override void AgentAction(float[] vectorAction, string textAction)
    {
        elapsedTime += Time.time - lastAction;//time elapsed since last action
        lastAction = Time.time;

        Collider[] obstacles = Physics.OverlapSphere(transform.position, 0.51f, LayerMask.GetMask("Obstacle"));

        bool hitObstacle = false;
        foreach(Collider c in obstacles)
        {
            Debug.Log("hit obstacle, distance:" + Vector3.Distance(transform.position, c.ClosestPoint(transform.position)));
            hitObstacle = true;
            AddReward(-1f);
            Done();//the agent hit an obstacle and failed
        }

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

        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = vectorAction[0];
        rb.AddForce(controlSignal * speed);
    }


}
