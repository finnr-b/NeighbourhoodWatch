using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    // Try again!
    public void RestartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    // Back to Menu
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    // Time to play something else.
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("The application has quit.");
    }
}