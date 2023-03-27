using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public AudioClip death;
    public virtual void OnDeath()
    {
        SoundManager.Instance.PlaySound(death, 1);
        animator.SetBool("death", true);
    }
}
