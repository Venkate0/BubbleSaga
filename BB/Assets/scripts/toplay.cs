using UnityEngine;
using UnityEngine.SceneManagement;
public class toplay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void ToPlay()
    {
        SceneManager.LoadScene("Scenes/Level 1");
    }
    public void ToQuit()
    {
        Application.Quit();
    }
}
