using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource source;

    //Music & background
    [Header("Music & background")]
    public AudioSource music;
    public AudioSource background;

    private void Awake()
    {
        Instance = this;
    }
    /// <summary>
    /// Play sound once with clip and volume
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="volume"></param>
    public void PlaySound(AudioClip clip, float volume)
    {
        source.PlayOneShot(clip, volume);
    }
    public void StopSound()
    {
        source.Stop();
    }
    /// <summary>
    /// Switch Sound track
    /// </summary>
    public void SwitchSoundTrack(AudioClip musicClip, AudioClip backgroundClip)
    {
        if (musicClip == music.clip)
            return;
        StartCoroutine(SmoothSwitch(musicClip, backgroundClip));
    }
    IEnumerator SmoothSwitch(AudioClip musicClip, AudioClip backgroundClip)
    {
        //Wait for the music to stop
        while (music.volume > 0)
        {
            music.volume -= Time.deltaTime;
            background.volume -= Time.deltaTime;
            yield return null;
        }
        music.volume = 0;
        background.volume = 0;

        //Stop old clips
        music.Stop();
        background.Stop();
        //Set new clips
        music.clip = musicClip;
        background.clip = backgroundClip;
        //Play new clips
        music.Play();
        background.Play();

        //Wait for  music 
        while (music.volume < 1)
        {
            music.volume += Time.deltaTime;
            background.volume += Time.deltaTime;
            yield return null;
        }
        music.volume = 1;
        background.volume = 1;
    }
}
