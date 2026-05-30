using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int lives = 3;
    public int targetScore = 30;
    public int highScore = 0;
    public bool gameOver = false;

    public GameObject gameOverPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI finalScoreText;

    void Awake()
    {
        Instance = this;
        // Laad de opgeslagen high score (0 als er nog niks is opgeslagen)
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void AddScore(int points)
    {
        if (gameOver) return;
        score += points;
        Debug.Log("Score: " + score);
    }

    public void LoseLife()
    {
        if (gameOver) return;
        lives--;
        Debug.Log("Lives: " + lives);

        if (lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameOver = true;
        Time.timeScale = 0f;

        bool won = score >= targetScore;

        // Check of dit een nieuwe high score is en sla 'm op
        bool newHighScore = score > highScore;
        if (newHighScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        gameOverPanel.SetActive(true);
        titleText.text = won ? "YOU WIN!" : "GAME OVER";
        finalScoreText.text = "Final score: " + score + "\nHigh score: " + highScore;
        if (newHighScore)
        {
            finalScoreText.text += "\nNEW HIGH SCORE!";
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}