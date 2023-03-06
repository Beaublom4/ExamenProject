using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool deathStarted = false;
    public virtual void OnDeath()
    {
        if (deathStarted)
            return;

        deathStarted = true;
        animator.SetBool("death", true);
    }
}
