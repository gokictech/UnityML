using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    public Transform container;
    public Vector3 riverSpeed;
    public bool addVelocityOnStart;

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

    public void Add(GameObject obj)
    {
        obj.transform.SetParent(container);
        Rigidbody objRb = obj.GetComponent<Rigidbody>();
        SetVelocity(objRb);
    }

    private void SetVelocity(Rigidbody rb)
    {
        rb.velocity = riverSpeed;
    }
}