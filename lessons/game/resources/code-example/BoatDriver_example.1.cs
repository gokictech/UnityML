using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatDriver : MonoBehaviour
{
  public float speed = 5f;
  private float horizontalInput;
  private BoatMovement movement;
    
  void Start()
  {
      movement = GetComponent<BoatMovement>();
  }
    
  private void Update()
  {
      horizontalInput = Input.GetAxis("Horizontal");
  }

  private void FixedUpdate()
  {
      movement.SetVelocity(Vector3.left * horizontalInput, speed);
  }
}
