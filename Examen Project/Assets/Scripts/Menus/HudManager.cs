using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public static HudManager Instance;
    public Slider healthSlider;

    public TMP_Text coinText;

    public GameObject GameOverScreen;

    private void Awake()
    {
        Instance = this;
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
    public void SetCoins(int coins)
    {
        coinText.text = "Coins: " + coins.ToString();
    }
    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
