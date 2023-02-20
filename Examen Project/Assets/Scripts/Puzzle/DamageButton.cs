using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the base class for all the puzzle buttons that need to react on taking damage.
/// </summary>
public class DamageButton : MonoBehaviour
{
    public virtual void TriggerOnDamage()
    {
        Debug.Log($"{name} got triggerd by damage");
    }
}
