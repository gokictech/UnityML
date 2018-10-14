using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleSetter : MonoBehaviour {


	public float timeScale;
	private float lastTimeScale;

	void Update () {

		if(lastTimeScale != timeScale)
		{
			Time.timeScale = timeScale;
			lastTimeScale = timeScale;
		}	
	}
}
