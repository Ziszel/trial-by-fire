using UnityEngine;

public class doorRotate : MonoBehaviour
{
    public Transform pivotPoint;

    public Transform camera;
    // Update is called once per frame
    void Update()
    {
        // Make the door stop rotating once the camera is past it
        if (camera.position.z < 0)
        {
            RotateAroundPoint();
        }
    }

    void RotateAroundPoint()
    {
        // Rotation guidance taken from the following webpage: https://gamedevbeginner.com/how-to-rotate-in-unity-complete-beginners-guide/#rotate_around_point
        transform.RotateAround(pivotPoint.position, Vector3.up, 60 * Time.deltaTime);
    }
}
