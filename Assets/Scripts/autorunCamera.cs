using System;
using UnityEditor.UIElements;
using UnityEngine;

public class autorunCamera : MonoBehaviour
{
    private float speed = 1.0f;

    private void Update()
    {
        transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
        speed += 0.02f;
    }
}
