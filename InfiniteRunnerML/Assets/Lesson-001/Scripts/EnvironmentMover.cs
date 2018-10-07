using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOKiC
{
    public class EnvironmentMover : MonoBehaviour
    {
        public float speed = 0.3f;
		public bool updateListOnStart = false;
        Transform[] objectsToMove;
        int childCount;

        void Start()
        {
			if(updateListOnStart)
				UpdateListOfMoveObjects();
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

            objectToMove.Translate(new Vector3(0f, 0f, speed));
        }
    }
}