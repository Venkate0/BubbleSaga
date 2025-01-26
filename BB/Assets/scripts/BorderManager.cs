using UnityEngine;

public class BorderManager : MonoBehaviour
{
    public static BorderManager Instance { get; private set; }

    public float minX = -10f;
    public float maxX = 50f;
    public float minY = -5f;
    public float maxY = 20f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
