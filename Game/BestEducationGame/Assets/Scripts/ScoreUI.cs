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
            int score = GameManager.Instance.score;
            int target = GameManager.Instance.targetScore;
            int high = GameManager.Instance.highScore;

            // Basis-kleur op wit; per regel kleuren we hieronder via <color>-tags
            scoreText.color = Color.white;

            // Score-regel: groen zodra het doel bereikt is
            string scoreColor = score >= target ? "green" : "white";
            // High score-regel: groen zodra de speler de oude high score voorbij gaat
            string highColor = score > high ? "green" : "white";

            scoreText.text = $"<color={scoreColor}>Score: {score}/{target}</color>\n<color={highColor}>High score: {high}</color>";
        }
    }
}