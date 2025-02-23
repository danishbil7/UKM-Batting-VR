using UnityEngine;

public class BallHitDetector : MonoBehaviour
{
    public GameManager gameManager; // Reference to the game manager
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to the ball
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bat"))
        {
            // The ball was hit by the bat
            gameManager.BallHit();
            PlayHitSound();
        }
    }

    void PlayHitSound()
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Play the hit sound effect
        }
    }
}