using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isGamePaused = false;
    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Debug.Log("Paused...");
        Time.timeScale = 0f;
        PauseMenuUI.SetActive(true);
        isGamePaused = true;
    }

    public void Resume()
    {
        Debug.Log("Resume...");
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
        isGamePaused = false;
    }

    public void Menu()
    {
        Debug.Log("Menu Button Pressed");
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
        Debug.Log("Quit Button Pressed");
        Application.Quit();
    }
}
