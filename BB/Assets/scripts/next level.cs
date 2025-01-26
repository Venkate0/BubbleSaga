using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTrigger : MonoBehaviour
{
    public string nextLevelName; // Name of the next level to load

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that triggered the collision is the player
        if (collision.CompareTag("Player"))
        {
            // Load the next level when the player reaches the endpoint
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        // Check if a next level is set
        if (!string.IsNullOrEmpty(nextLevelName))
        {
            SceneManager.LoadScene("Scenes/Level3"); // Load the next level
        }
        else
        {
            Debug.LogError("Next level name is not set.");
        }
    }
}
