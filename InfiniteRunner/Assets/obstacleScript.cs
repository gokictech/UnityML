using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleScript : MonoBehaviour {

    public float speed = 0.05f;

	void FixedUpdate () {
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
