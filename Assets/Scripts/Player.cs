using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float force = 24.0f;
    private float rotationSpeed = 50.0f;
    private Rigidbody rb;
    private bool canMove = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // store movement
        // The below comment I used in combination with the Unity documentation: https://docs.unity3d.com/ScriptReference/index.html
        // in order to understand rotations and how they work in Unity.
        // https://gamedevbeginner.com/how-to-rotate-in-unity-complete-beginners-guide/

        if (canMove)
        {
            // GetAxisRaw will return -1 or 1 with no scaling in-between
            float zMovement = Input.GetAxisRaw("Vertical");
            float rotation = Input.GetAxisRaw("Horizontal") * rotationSpeed;

            if (zMovement > 0)
            {
                // transform.forward allows for forward movement dependant on rotation of object
                rb.velocity = transform.forward * force;
            }
            else if (zMovement < 0)
            {
                rb.velocity = -transform.forward * force;
            }

            transform.Rotate(new Vector3(.0f, rotation, 0.0f) * Time.deltaTime);
        }
    }

    public void setMove(bool ableToMove)
    {
        canMove = ableToMove;
    }
}
