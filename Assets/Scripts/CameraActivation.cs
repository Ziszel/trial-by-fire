using System;
using UnityEngine;

public class CameraActivation : MonoBehaviour
{
    public Camera localCamera;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(Camera.main);
        localCamera.enabled = true;
        //m_MainCamera.enabled = false;
    }
    
    private void OnTriggerExit(Collider other)
    {
        localCamera.enabled = false;
        //m_MainCamera.enabled = true;
    }
}
