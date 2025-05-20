using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class logic : MonoBehaviour
{
    public int playerScore;
    public Text scoreText; // Normal score display during gameplay
    public GameObject gameOverScreen; // The main game over screen
    public GameObject gameOverPanel; // Additional panel to show on game over
    public Text gameOverText; // Additional text to show on game over

    // Adds points to the player's score
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        UpdateScoreText();
    }

    // Updates the score text
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = playerScore.ToString();
        }
        else
        {
            Debug.LogWarning("Score Text is not assigned in the Inspector.");
        }
    }

    // Restarts the game
    public void restartGame()
    {
        // Reset time scale in case game was paused
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Handles game over state
    public void gameOver()
    {
        // Show game over screen
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Game Over Screen is not assigned in the Inspector.");
        }

        // Show additional panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Game Over Panel is not assigned in the Inspector.");
        }

        // Update and show additional text
        if (gameOverText != null)
        {
            gameOverText.text = "Game Over! Final Score: " + playerScore;
            gameOverText.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Game Over Text is not assigned in the Inspector.");
        }

        // Optional: Pause the game
        Time.timeScale = 0f;
    }
}