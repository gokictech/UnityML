using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    public Transform container;
    public Vector3 riverSpeed;
    public bool addVelocityOnStart;

    public void Add(GameObject obj)
    {
        obj.transform.SetParent(container);
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        SetVelocity(rb);
    }

    private void SetVelocity(Rigidbody rb)
    {
        rb.velocity = riverSpeed;
    }
}