using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    // Wordt aangeroepen wanneer de speler op de Start-knop drukt
    public void StartGame()
    {
        SceneManager.LoadScene("InstructionsScene");
    }
}