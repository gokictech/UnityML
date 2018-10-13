using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GOKiC
{
    public class Boat : MonoBehaviour
    {
		public static int highestTimeAlive = 0;
		public int collectedTrash;
        
		public bool isAlive;

		public float timeAlive;
		public string boatName;
        
		private void Start()
		{
			isAlive = true;
		}

		public void Reset()
		{
			transform.localPosition = new Vector3(-10, -0.05f, 10);
			timeAlive = 0f;
			isAlive = true;
		}

		public void Update()
		{
			// timeAlive += Time.deltaTime;

			// if((int)timeAlive > highestTimeAlive)
			// {
			// 	highestTimeAlive = (int)timeAlive;
			// 	Debug.Log("NEW RECORD! ["+boatName+"] :" + highestTimeAlive);
			// }
		}

		public void HitObstacle(Obstacle obstacle)
		{
			Destroy(obstacle.gameObject);
			isAlive = false;

			gameObject.transform.parent.GetComponentInChildren<EnvironmentMover>().multiplier = 0;

			gameObject.GetComponentInParent<GameManager>().ResetGame();

			Reset();
		}
		public void HitTrash(Trash trash)
		{
			CollectTrash(trash);
		}

		private void CollectTrash(Trash trash)
		{
			collectedTrash += 1;
			Destroy(trash.gameObject);
		}
    }
}
