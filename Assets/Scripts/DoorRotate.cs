using UnityEngine;

public class DoorRotate : MonoBehaviour
{
    public Transform pivotPoint; // the point where we want the door to rotate around.
    public Transform sceneCamera;
    // Update is called once per frame
    private void Update()
    {
        // Make the door stop rotating once the camera is past it
        if (sceneCamera.position.z < 0)
        {
            RotateAroundPoint();
        }
    }

    private void RotateAroundPoint()
    {
        // Rotation guidance taken from the following webpage: https://gamedevbeginner.com/how-to-rotate-in-unity-complete-beginners-guide/#rotate_around_point
        transform.RotateAround(pivotPoint.position, Vector3.up, 60 * Time.deltaTime);
    }
}
