using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {

    public float speed = 0.03f;
	
    //move towards the end of the lane until it is behind the runner, then destroy
	void FixedUpdate () {
        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(new Vector3(0f, 0f, -speed));
        }
	}
}
