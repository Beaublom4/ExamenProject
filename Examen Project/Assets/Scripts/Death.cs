using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public virtual void OnDeath()
    {

        animator.SetBool("death", true);
    }
}
