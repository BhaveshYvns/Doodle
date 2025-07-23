using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static bool GameisPaused = false; // Tracks if the game is paused
    public GameObject PauseMenuP; // Reference to the pause menu panel

    public void StartGame()
    {
        SceneManager.LoadScene(1); // Load scene at index 0
    }

    public void Quit()
    {
        Application.Quit(); // Quit the application
        Debug.Log("Quit Game"); // Useful for testing in the editor
    }

    void Update()
    {
        // Check for the Escape key press to toggle the pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuP.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f; // Resume game time
        GameisPaused = false; // Update pause state
    }

    void Pause()
    {
        PauseMenuP.SetActive(true); // Show the pause menu
        Time.timeScale = 0f; // Pause game time
        GameisPaused = true; // Update pause state
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f; // Ensure game time is normal before switching scenes
        SceneManager.LoadScene(0); // Load scene at index 2 (main menu)
    }
}