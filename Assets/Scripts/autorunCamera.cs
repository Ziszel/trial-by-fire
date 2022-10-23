using System;
using UnityEngine;

public class autorunCamera : MonoBehaviour
{
    private float speed = 1.0f;
    public Transform sceneCamera;
    private void Update()
    {
        // Make the camera stop moving
        if (sceneCamera.position.z < 2)
        {
            // move camera forward at increasing speed until past the door
            transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
            speed += 0.02f;   
        }
    }
}
