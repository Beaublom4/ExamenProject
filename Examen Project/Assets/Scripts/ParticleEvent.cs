using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEvent : MonoBehaviour
{
    [SerializeField] ParticleSystem system;

    public void PlayParticle()
    {
        system.Play();
    }
    public void StopParticle()
    {
        system.Stop();
    }
}
