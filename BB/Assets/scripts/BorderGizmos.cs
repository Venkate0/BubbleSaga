using UnityEngine;

public class BorderGizmos : MonoBehaviour
{
    public Color borderColor = Color.red; // Color of the borders in the Scene view

    void OnDrawGizmos()
    {
        Gizmos.color = borderColor;

        // Fetch values from BorderManager every frame
        float minX = BorderManager.Instance.minX;
        float maxX = BorderManager.Instance.maxX;
        float minY = BorderManager.Instance.minY;
        float maxY = BorderManager.Instance.maxY;

        // Draw left border
        Gizmos.DrawLine(new Vector3(minX, minY, 0), new Vector3(minX, maxY, 0));

        // Draw right border
        Gizmos.DrawLine(new Vector3(maxX, minY, 0), new Vector3(maxX, maxY, 0));

        // Draw top border
        Gizmos.DrawLine(new Vector3(minX, maxY, 0), new Vector3(maxX, maxY, 0));

        // Draw bottom border
        Gizmos.DrawLine(new Vector3(minX, minY, 0), new Vector3(maxX, minY, 0));
    }
}
