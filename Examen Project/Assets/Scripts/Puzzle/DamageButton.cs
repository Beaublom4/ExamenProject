using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This function should be called from a source of damage by the player.
/// </summary>
public class DamageButton : MonoBehaviour
{
    public virtual void TriggerOnDamage()
    {
        
        Debug.Log($"{name} got triggerd by damage");
    }
}
