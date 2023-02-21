using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject optionsPanel;

    /// <summary>
    /// Play game and switch scene to game scen
    /// </summary>
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    /// <summary>
    /// Go to settings and set options panel active
    /// </summary>
    public void Settings()
    {
        optionsPanel.SetActive(true);
    }
    /// <summary>
    /// Quit application
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
