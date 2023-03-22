using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public static HudManager Instance;
    public Slider healthSlider;

    public TMP_Text coinText;

    public GameObject GameOverScreen;
    public GameObject retryButton;
    [Space]
    public GameObject settingsObj;
    public GameObject continueObj;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (Input.GetButtonDown("PauseMenu"))
        {
            TogglePauseMenu();
        }
    }
    /// <summary>
    /// Set health slider in the hud
    /// </summary>
    /// <param name="currentHealth"></param>
    /// <param name="maxHealth"></param>
    public void SetHealth(int currentHealth, int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }
    /// <summary>
    /// Set coins in ui
    /// </summary>
    /// <param name="coins"></param>
    public void SetCoins(int coins)
    {
        coinText.text = "Coins: " + coins.ToString();
    }
    /// <summary>
    /// Enable game over screen
    /// </summary>
    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        FindObjectOfType<EventSystem>().SetSelectedGameObject(retryButton);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void TogglePauseMenu()
    {
        settingsObj.SetActive(!settingsObj.activeSelf);
        if (settingsObj.activeSelf)
        {
            Time.timeScale = 0;
            FindObjectOfType<EventSystem>().SetSelectedGameObject(continueObj);
        }
        else
            Time.timeScale = 1;
    }
}
