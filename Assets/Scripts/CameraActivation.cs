using UnityEngine;

public class CameraActivation : MonoBehaviour
{
    public Camera localCamera;

    private void OnTriggerEnter(Collider other)
    {
        // The previous method of 'moving the camera' was to actually have multiple cameras for each different angle that I wanted captured.
        // Unfortunately this resulted in severe lag that made the game unplayable.
        // I devised the below method to move a single camera around to a location dependant on the object (ref by name) that has been entered
        switch (name)
        {
            case "TriggerZone Cam 1":
                // setCameraPosRot takes in all the values that I care about:
                // x, y, z position
                // x, y, z rotation
                // depthOfField
                // clip distance far (how long to draw before no longer rendering)
                setCameraPosRot(localCamera, 7.6f, 10.5f, -14, 42.4f, 226.6f, 2.6f, 110.2f, 50.0f);
                break;
            case "TriggerZone Cam 2":
                setCameraPosRot(localCamera, 0.05f, 22.0f, 0.06f, 87.3f, 299.2f, 29.0f, 59.2f, 50.0f);
                break;
            case "TriggerZone Cam 3":
                setCameraPosRot(localCamera, 0.3f, 4.0f, -0.8f, 0.0f, -20.6f, 0.0f, 59.2f, 200.0f);
                break;
            case "TriggerZone Cam 4":
                setCameraPosRot(localCamera, -24.9f, 8.1f, 45.8f, 0.0f, 103.5f, 0.0f, 59.2f, 50.0f);
                break;
            case "TriggerZone Cam 5":
                setCameraPosRot(localCamera, -102.5f, 27.9f, 56.2f, 23.6f, 110.2f, 0.0f, 59.2f, 200.0f);
                break;
            case "TriggerZone Cam 6":
                setCameraPosRot(localCamera, -136.4f, 0.17f, 25.7f, -14.5f, 57.5f, -1.41f, 42.2f, 200.0f);
                break;
            case "TriggerZone Cam 7":
                setCameraPosRot(localCamera, -128.74f, 2.25f, 26.08f, -17f, 325f, 0.0f, 80.7f, 150.0f);
                break;
            case "TriggerZone Cam 8":
                setCameraPosRot(localCamera, -153.85f, 33.5f, 40.04f, 20.0f, 30.0f, 0.0f, 80.7f, 150.0f);
                break;
            case "TriggerZone Cam 9":
                setCameraPosRot(localCamera, -140.9f, 36.3f, 67.22f, 30.0f, 0.0f, 0.0f, 80.7f, 150.0f);
                break;
            case "TriggerZone Cam 10":
                setCameraPosRot(localCamera, -138.0f, 5.7f, 193.27f, 0.0f, 180.0f, 0.0f, 50.4f, 400.0f);
                break;
            default:
                break;
        }
    }

    void setCameraPosRot(Camera camera, float px, float py, float pz, float rx, float ry, float rz, float depthOfField, float clipFar)
    {
        // position updates the camera by world position
        camera.transform.position = new Vector3(px, py, pz);
        // Quaternion.Euler rotates the object around itself (x co-ords around the x axis, etc...)
        camera.transform.rotation = Quaternion.Euler(rx, ry, rz);
        camera.fieldOfView = depthOfField;
        camera.farClipPlane = clipFar;
    }
}
