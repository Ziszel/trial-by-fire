using UnityEngine;

public class Player : MonoBehaviour
{
    private float _force = 24.0f;
    private const float RotationSpeed = 50.0f;
    private Rigidbody _rb;
    private bool _canMove = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // store movement
        // The below comment I used in combination with the Unity documentation: https://docs.unity3d.com/ScriptReference/index.html
        // in order to understand rotations and how they work in Unity.
        // https://gamedevbeginner.com/how-to-rotate-in-unity-complete-beginners-guide/

        if (_canMove)
        {
            // GetAxisRaw will return -1 or 1 with no scaling in-between
            float zMovement = Input.GetAxisRaw("Vertical");
            float rotation = Input.GetAxisRaw("Horizontal") * RotationSpeed;

            if (zMovement > 0)
            {
                // Adds the ability for the player to run!
                _force = (Input.GetKey(KeyCode.LeftShift)) ? _force = 50.0f : _force = 24.0f;
                // transform.forward allows for forward movement dependant on rotation of object
                _rb.velocity = transform.forward * _force;
            }
            else if (zMovement < 0)
            {
                _force = (Input.GetKey(KeyCode.LeftShift)) ? _force = 50.0f : _force = 24.0f;
                _rb.velocity = -transform.forward * _force;
            }

            transform.Rotate(new Vector3(.0f, rotation, 0.0f) * Time.deltaTime);
        }
    }

    public void SetMove(bool ableToMove)
    {
        _canMove = ableToMove;
        _canMove = ableToMove;
    }
}
