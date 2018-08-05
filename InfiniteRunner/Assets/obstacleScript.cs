using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleScript : MonoBehaviour {

    //distance the obstacle moves towards the agent every physics update
    public float speed = 0.05f;

	void FixedUpdate () {
        //delete after it passes agent
	    if(transform.position.z <= -0.5f)
        {
            Destroy(this.gameObject);
        }
        else
        {
            gameObject.transform.Translate(new Vector3(0f, 0f, -speed));
        }


	}
}
