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
    [Space]
    public AudioClip buttonHover;
    public AudioClip buttonPress;
    [Space]
    public Image cover;

    private void Awake()
    {
        Instance = this;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        if (Input.GetButtonDown("PauseMenu"))
        {
            if (DialogManager.Instance.messageBox.activeSelf)
                return;
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
    public void PlayButtonHover() 
    {
        SoundManager.Instance.PlaySound(buttonHover, 1);
    }
    public void PlayButtonPress()
    {
        SoundManager.Instance.PlaySound(buttonPress, 1);
    }
    [ContextMenu("FadeIn")]
    public void FadeIn()
    {
        StartCoroutine(FadeRoutine(true));
    }
    [ContextMenu("FadeOut")]
    public void FadeOut()
    {
        StartCoroutine(FadeRoutine(false));
    }
    IEnumerator FadeRoutine(bool fadeIn)
    {
        Debug.Log(fadeIn);
        if (fadeIn) 
        {
            cover.color = new Color(0, 0, 0, 0);
            while (cover.color.a < .95f)
            {
                cover.color = Color.Lerp(cover.color, new Color(0, 0, 0, 1), .05f);
                Debug.Log(cover.color.a);
                yield return null;
            }
            cover.color = Color.black;
            DialogManager.hasFinished = true;
            SceneManager.LoadScene("Game");
        }
        else
        {
            cover.color = new Color(0, 0, 0, 1);
            while (cover.color.a > 0.05f)
            {
                cover.color = Color.Lerp(cover.color, new Color(0, 0, 0, 0), .05f);
                Debug.Log(cover.color.a);
                yield return null;
            }
            cover.color = new Color(0, 0, 0, 0);
        }
    }
}
