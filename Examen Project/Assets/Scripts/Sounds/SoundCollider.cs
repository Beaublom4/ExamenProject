using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCollider : MonoBehaviour
{
    public AudioClip musicClip, backgroundClip;
    public GameObject directionalLight;
    public bool directionalLightToggle;

    private void OnTriggerEnter(Collider other)
    {
        SoundManager.Instance.SwitchSoundTrack(musicClip, backgroundClip);
        directionalLight.SetActive(directionalLightToggle);
    }
}
