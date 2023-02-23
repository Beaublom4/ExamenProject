using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public static HudManager Instance;
    public Slider healthSlider;

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
    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }
}
