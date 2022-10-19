using UnityEngine;

public class CameraActivation : MonoBehaviour
{
    public Camera localCamera;
    
    private void OnTriggerEnter(Collider other)
    {
        localCamera.enabled = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        localCamera.enabled = false;
    }
}
