using System;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float force = 50;
    private float rotationSpeed = 25.0f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // store movement
        float zMovement = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Horizontal") *  rotationSpeed;
        rotation *= Time.deltaTime;

        var movement = new Vector3(0.0f, 0.0f, zMovement);
        
        transform.Rotate(0.0f, rotation, 0.0f);
        rb.AddForce(movement * force);
    }
}
