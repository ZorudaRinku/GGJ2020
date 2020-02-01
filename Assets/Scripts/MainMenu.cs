using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public void Play ()
    {
        Debug.Log("Play Button Pressed");
        EventSystem.current.SetSelectedGameObject(null);
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        Debug.Log("Options Button Pressed");
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void Quit()
    {
        Debug.Log("Quit Button Pressed");
        Application.Quit();
    }
}
