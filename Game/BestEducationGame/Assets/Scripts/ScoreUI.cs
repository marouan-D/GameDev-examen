using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (GameManager.Instance != null)
        {
            scoreText.text = "Score: " + GameManager.Instance.score + "\nHigh score: " + GameManager.Instance.highScore;
        }
    }
}