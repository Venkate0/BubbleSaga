using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform cameraTransform; // Reference to the camera's transform

    void LateUpdate()
    {
        // Follow the camera's position
        transform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y, transform.position.z);
    }
}
