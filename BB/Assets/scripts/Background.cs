using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform playerTransform;

    void Update()
    {
        
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }
}
