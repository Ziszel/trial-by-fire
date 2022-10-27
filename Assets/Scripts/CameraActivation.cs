using System;
using UnityEngine;

public class CameraActivation : MonoBehaviour
{
    public Camera localCamera;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(localCamera.name);
        //localCamera.enabled = true;
        switch (name)
        {
            case "TriggerZone Cam 1":
                setCameraOne(localCamera);
                Debug.Log("updated camera");
                break;
            case "TriggerZone Cam 2":
                setCameraTwo(localCamera);
                break;
            default:
                break;
        }
        
    }
    
    /*private void OnTriggerExit(Collider other)
    {
        localCamera.enabled = false;
    }*/

    void setCameraOne(Camera camera)
    {
        float px = 0.35f;
        float py = 10.5f;
        float pz = 0.5f;
        camera.transform.position = new Vector3(px, py, pz);

        //float rx = 42.4f;
        //float ry = 226.6f;
        //float rz = 2.6f;
        //camera.transform.rotation = Quaternion.Euler(rx, ry, rz);

        camera.fieldOfView = 110.2f;
    }
    
    void setCameraTwo(Camera camera)
    {
        float px = 10.35f;
        float py = 110.5f;
        float pz = 10.5f;
        camera.transform.position = new Vector3(px, py, pz);

        float rx = 42.4f;
        float ry = 226.6f;
        float rz = 2.6f;
        camera.transform.rotation = Quaternion.Euler(rx, ry, rz);
    }
}
