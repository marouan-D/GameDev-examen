using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int lives = 3;
    public int targetScore = 30;
    public bool gameOver = false;

    // UI-referenties — sleep deze in de Inspector
    public GameObject gameOverPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI finalScoreText;

    void Awake()
    {
        Instance = this;
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

        // Toon het game over scherm
        gameOverPanel.SetActive(true);
        titleText.text = won ? "YOU WIN!" : "GAME OVER";
        finalScoreText.text = "Final score: " + score;
    }

    // Wordt aangeroepen wanneer de speler op de Play Again knop drukt
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}