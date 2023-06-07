using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;
    private bool isFullscreen = false;

    private void Update()
    {
        // Pause and resume the game on pressing Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        // Toggle fullscreen on pressing F
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFullscreen();
        }
    }

    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pause the game by setting time scale to 0
        Cursor.lockState = CursorLockMode.None; // Re-enable the cursor
        Cursor.visible = true;
    }

    private void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume the game by setting time scale back to 1
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor again
        Cursor.visible = false;
    }

    private void ToggleFullscreen()
    {
        Debug.Log("Toggling FullScreen");
        isFullscreen = !isFullscreen;

        // Toggle fullscreen mode
        Screen.fullScreen = isFullscreen;
    }
}