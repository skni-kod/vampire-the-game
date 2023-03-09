using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if(isGamePaused)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = !isGamePaused;
        }
    }   

    public void ResumeGame()
    {
        isGamePaused = !isGamePaused;
    }

    public void QuitPauseMenu()
    {
        isGamePaused = false;
        SceneManager.LoadScene("MainMenu");
    }

}