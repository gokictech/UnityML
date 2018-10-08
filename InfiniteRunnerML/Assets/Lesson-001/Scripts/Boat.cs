using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GOKiC
{
    public class Boat : MonoBehaviour
    {
		public int collectedTrash;
        
		public bool isAlive;
        
		private void Start()
		{
			isAlive = true;
		}

		public void HitObstacle(Obstacle obstacle)
		{
			Destroy(obstacle.gameObject);
			isAlive = false;

			GameObject.FindObjectOfType<EnvironmentMover>().multiplier = 0;
			
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
