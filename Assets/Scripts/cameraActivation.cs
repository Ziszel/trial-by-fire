using System;
using UnityEngine;

public class cameraActivation : MonoBehaviour
{
    //public Transform player;
    public Camera localCamera;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        localCamera.enabled = true;
        mainCamera.enabled = false;
    }
    
    private void OnTriggerExit(Collider other)
    {
        mainCamera.enabled = true;
        localCamera.enabled = false;
    }
}
