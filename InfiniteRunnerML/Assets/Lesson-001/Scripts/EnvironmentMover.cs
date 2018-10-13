using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOKiC.LessonPassOne
{
    public class EnvironmentMover : MonoBehaviour
    {
        
        public float multiplier = 1f;
        public float speed = 0.3f;
		public bool updateListOnStart = false;
        private Transform[] objectsToMove;
        private int childCount;

        private float initialMultiplier;

        void Start()
        {
			if(updateListOnStart)
				UpdateListOfMoveObjects();
            
            initialMultiplier = multiplier;
        }

        void Update()
        {
			if(objectsToMove == null)
				return;

            var objs = objectsToMove;
            foreach (Transform obj in objs)
            {
                Move(obj);
            }
        }

        public void UpdateListOfMoveObjects()
        {
            childCount = transform.childCount;

            objectsToMove = new Transform[childCount];
            for (int i = 0; i < childCount; i++)
            {
                objectsToMove[i] = transform.GetChild(i);
            }
        }

        public void Move(Transform objectToMove)
        {
            if(objectToMove == null)
                return;

            objectToMove.Translate(new Vector3(0f, 0f, speed*Time.timeScale));
        }

        public float GetInitialMultiplier()
        {
            return initialMultiplier;
        }
    }
}