using System;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float zSpeed = 8.0f;
    private float ySpeed = 50.0f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX;
    }

    // Update is called once per frame
    void Update()
    {
        float zTranslation = (Input.GetAxis("Vertical") * zSpeed) * Time.deltaTime;
        float yTranslation = (Input.GetAxis("Horizontal") * ySpeed) * Time.deltaTime;

        transform.Translate(0.0f, 0.0f, zTranslation);
        transform.Rotate(0.0f, yTranslation, 0.0f);
    }
}
