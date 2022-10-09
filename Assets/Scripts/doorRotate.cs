using UnityEngine;

public class doorRotate : MonoBehaviour
{
    public Transform pivotPoint;

    private int testCount = 0;
    // Update is called once per frame
    void Update()
    {
        RotateAroundPoint();
    }

    void RotateAroundPoint()
    {
        // Rotation guidance taken from the following webpage: https://gamedevbeginner.com/how-to-rotate-in-unity-complete-beginners-guide/#rotate_around_point
        transform.RotateAround(pivotPoint.position, Vector3.up, 60 * Time.deltaTime);
    }
}
