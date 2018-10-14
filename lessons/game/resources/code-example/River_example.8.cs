using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    public Transform container;
    public Vector3 riverSpeed;
    public bool addVelocityOnStart;
    public Transform endOfRiverObserver;

	private List<Transform> riverObjects;

    private void Start()
    {
        if (addVelocityOnStart)
        {
            foreach (Transform obj in container)
            {
                Add(obj.gameObject);
            }
        }
    }

    
    private void Update()
	{
		RemoveAtEndOfRiver();
	}

    public void Add(GameObject obj)
    {
        obj.transform.SetParent(container);
        Rigidbody objRb = obj.GetComponent<Rigidbody>();

        if(objRb == null)
        {
            Debug.LogError(obj.name + " does not contain a Rigidbody");
            return;
        }
        
        SetVelocity(objRb);

        if(riverObjects == null)
        {
            riverObjects = new List<Transform>();
        }
        riverObjects.Add(obj.transform);
    }

    private void SetVelocity(Rigidbody rb)
    {
        rb.velocity = riverSpeed;
    }

    private void RemoveAtEndOfRiver()
	{
		int count = riverObjects.Count;

		for(int i = count -1; i >=0 ; i--)
		{                
			if(riverObjects[i].position.z > endOfRiverObserver.position.z)
			{
				Transform obj  = riverObjects[i];
				riverObjects.RemoveAt(i);
				Destroy(obj.gameObject);
			}
		}
	}
}