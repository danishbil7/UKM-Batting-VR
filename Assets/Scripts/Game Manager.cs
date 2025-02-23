using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component for displaying the score
    public TextMeshProUGUI endGameText; // Reference to the TextMeshProUGUI component for displaying the end game message
    private int score = 0; // Variable to store the score
    private int maxScore = 50; // Maximum score to end the game

    void Start()
    {
        UpdateScoreText(); // Initialize the score display
        if (endGameText != null)
        {
            endGameText.gameObject.SetActive(false); // Hide the end game message at the start
        }
    }

    public void BallHit()
    {
        score += 10; // Increase score by 10 for each hit (or any value you prefer)
        UpdateScoreText(); // Update the score display

        if (score >= maxScore)
        {
            EndGame(); // End the game when the score reaches or exceeds maxScore
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; 
    }

    void EndGame()
    {
        // Display end game message
        if (endGameText != null)
        {
            endGameText.text = "Congratulations! You've reached the maximum score!";
            endGameText.gameObject.SetActive(true);
        }

        // Stop the game or perform other end game actions
        Time.timeScale = 0; // Freeze the game
        
    }
}
