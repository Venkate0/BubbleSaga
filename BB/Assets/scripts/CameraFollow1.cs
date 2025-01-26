using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player GameObject
    public Vector3 offset; // Offset from the player
    public float smoothSpeed = 0.125f; // Speed of the smoothing effect

    void LateUpdate()
    {
        // Fetch values from BorderManager every frame
        float minX = BorderManager.Instance.minX;
        float maxX = BorderManager.Instance.maxX;
        float minY = BorderManager.Instance.minY;
        float maxY = BorderManager.Instance.maxY;

        // Follow the player's position with an offset
        Vector3 targetPosition = player.position + offset;

        // Clamp the target position to the specified boundaries
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

        // Smooth the transition
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
