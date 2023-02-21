using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    public AudioMixer mixer;

    public static float volume;
    public static bool windowed;
    public static int resolution;

    public Slider soundSlider;
    public Toggle windowModeToggle;
    public TMP_Dropdown ResolutionDropDown;

    private void Start()
    {
        
    }
    /// <summary>
    /// Set the volume with calculation volume
    /// </summary>
    /// <param name="value"></param>
    public void SetVolume(float value)
    {
        volume = value;
        mixer.SetFloat("Master", Mathf.Log10(value) * 20);
    }
    /// <summary>
    /// Set windowed mode to toggle
    /// </summary>
    /// <param name="toggle"></param>
    public void SetWindowedMode(bool toggle)
    {
        windowed = toggle;
        Screen.fullScreen = !toggle;
    }
    /// <summary>
    /// Set resolution to different options
    /// </summary>
    /// <param name="dropdown"></param>
    public void SetResolution(int dropdown)
    {
        resolution = dropdown;
        switch (dropdown) 
        {
            case 0:
                Screen.SetResolution(2560, 1440, Screen.fullScreen);
                break;
            case 1: 
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
            case 3:
                Screen.SetResolution(640, 360, Screen.fullScreen);
                break;
        }
    }
    /// <summary>
    /// Return out of options
    /// </summary>
    public void Return()
    {
        gameObject.SetActive(false);
    }
}
