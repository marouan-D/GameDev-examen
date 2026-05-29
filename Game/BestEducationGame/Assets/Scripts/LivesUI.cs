using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    private TextMeshProUGUI livesText;

    void Start()
    {
        livesText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (GameManager.Instance != null)
        {
            livesText.text = "Lives: " + GameManager.Instance.lives;
        }
    }
}