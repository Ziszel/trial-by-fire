using System;
using UnityEngine;

public class CameraActivation : MonoBehaviour
{
    public Camera localCamera;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(Camera.main);
        localCamera.enabled = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        localCamera.enabled = false;
    }
}
