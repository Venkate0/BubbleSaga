using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip backgroundMusic; // Reference to the background music clip
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Play the background music if it’s not already playing
        if (!audioSource.isPlaying)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true; // Set to loop
            audioSource.Play(); // Play the music
        }
    }

    // Optionally, you can add methods to control the music during the game
    public void SetVolume(float volume)
    {
        audioSource.volume = volume; // Set the volume (0.0 to 1.0)
    }

    public void StopMusic()
    {
        audioSource.Stop(); // Stop the music
    }

    public void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play(); // Start playing the music if it's not playing
        }
    }
}
