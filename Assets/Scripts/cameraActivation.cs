using UnityEngine;

public class cameraActivation : MonoBehaviour
{
    //public Transform player;
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
