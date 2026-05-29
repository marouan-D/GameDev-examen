using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    // Verwijzing naar de tekst-component op dit GameObject
    private TextMeshProUGUI scoreText;

    void Start()
    {
        // Pak de tekst-component automatisch op
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Werk de tekst elke frame bij met de huidige score
        if (GameManager.Instance != null)
        {
            scoreText.text = "Score: " + GameManager.Instance.score;
        }
    }
}