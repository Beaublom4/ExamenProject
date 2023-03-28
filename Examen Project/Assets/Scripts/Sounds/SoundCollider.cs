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
        if (other.tag != "Player")
            return;
        SoundManager.Instance.SwitchSoundTrack(musicClip, backgroundClip);
        if (directionalLight == null)
            return;
        directionalLight.SetActive(directionalLightToggle);
    }
}
