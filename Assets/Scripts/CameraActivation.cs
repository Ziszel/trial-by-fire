using System;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

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
                setCameraPosRot(localCamera, 7.6f, 10.5f, -14, 42.4f, 226.6f, 2.6f, 110.2f, 50.0f);
                Debug.Log("updated camera");
                break;
            case "TriggerZone Cam 2":
                setCameraPosRot(localCamera, 0.05f, 22.0f, 0.06f, 87.3f, 299.2f, 29.0f, 59.2f, 50.0f);
                break;
            case "TriggerZone Cam 3":
                setCameraPosRot(localCamera, 0.3f, 0.72f, -0.8f, 0.0f, -20.6f, 0.0f, 59.2f, 200.0f);
                break;
            case "TriggerZone Cam 4":
                setCameraPosRot(localCamera, -24.9f, 8.1f, 45.8f, 0.0f, 103.5f, 0.0f, 59.2f, 50.0f);
                break;
            case "TriggerZone Cam 5":
                setCameraPosRot(localCamera, -102.5f, 27.9f, 56.2f, 23.6f, 110.2f, 0.0f, 59.2f, 200.0f);
                break;
            case "TriggerZone Cam 6":
                setCameraPosRot(localCamera, -0.74f, 1.72f, -0.49f, 13.4f, 56.8f, -1.41f, 42.2f, 200.0f);
                break;
            case "TriggerZone Cam 7":
                setCameraPosRot(localCamera, -0.38f, 2.6f, -0.43f, -20f, 35f, 0.0f, 59.2f, 150.0f);
                break;
            case "TriggerZone Cam 8":
                setCameraPosRot(localCamera, 1.32f, 33.2f, -0.43f, 20.0f, -57.9f, 0.0f, 59.2f, 150.0f);
                break;
            case "TriggerZone Cam 9":
                setCameraPosRot(localCamera, 0.72f, 37.5f, -0.18f, 28.1f, -87.3f, 0.0f, 59.2f, 150.0f);
                break;
            case "TriggerZone Cam 10":
                setCameraPosRot(localCamera, -0.18f, 5.7f, 0.12f, 0.0f, 90.0f, 0.0f, 59.2f, 400.0f);
                break;
            default:
                break;
        }
        
    }
    
    /*private void OnTriggerExit(Collider other)
    {
        localCamera.enabled = false;
    }*/

    void setCameraPosRot(Camera camera, float px, float py, float pz, float rx, float ry, float rz, float depthOfField, float clipFar)
    {
        camera.transform.position = new Vector3(px, py, pz);
        camera.transform.rotation = Quaternion.Euler(rx, ry, rz);
        camera.fieldOfView = depthOfField;
        camera.farClipPlane = clipFar;
    }
}
