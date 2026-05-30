using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsSceneController : MonoBehaviour
{
    // Wordt aangeroepen wanneer de speler op OK drukt
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}