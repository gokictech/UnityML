using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOKiC
{
    public class Boat : MonoBehaviour
    {
		public string boatName = "Boat";
		public Transform initialPosition;

		public float timeAlive;
		public int trashCollected;

		void Start()
		{
			if(initialPosition == null)
			{
				Debug.LogError("initialPosition is not set.");
				return;
			}
		}

		void Update()
		{
			timeAlive += Time.deltaTime;
			SinglePlayer_GameScore.Instance.SetScore(boatName, (int)(timeAlive * (trashCollected == 0 ? 1 :trashCollected)));
		}

		void OnCollisionEnter(Collision other)
		{
			Obstacle obstacle = other.gameObject.GetComponent<Obstacle>();
			if(obstacle != null)
			{
				Debug.Log("hit an obstacle");
				Destroy(other.gameObject);
				Reset();
				return;
			}

			Trash trash = other.gameObject.GetComponent<Trash>();
			if(trash != null)
			{
				Debug.Log("hit trash");
				Destroy(other.gameObject);
				trashCollected++;
				return;
			}

			Debug.Log("Collided with : " + other.gameObject.name);
			Reset();
		}

		private void Reset()
		{
			transform.position = initialPosition.position;
			timeAlive = 0f;
			trashCollected = 0;
		}
    }
}
