using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player GameObject
    public Vector3 offset; // Offset from the player
    public float minX; // Minimum X boundary
    public float maxX; // Maximum X boundary
    public float minY; // Minimum Y boundary
    public float maxY; // Maximum Y boundary
    public float smoothSpeed = 0.125f; // Speed of the smoothing effect

    void LateUpdate()
    {
        // Follow the player's position with an offset
        Vector3 targetPosition = player.position + offset;

        // Clamp the target position to the specified boundaries
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

        // Smooth the transition
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
