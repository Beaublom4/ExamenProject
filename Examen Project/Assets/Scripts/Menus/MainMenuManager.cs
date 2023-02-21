using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject optionsPanel;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Settings()
    {
        optionsPanel.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
