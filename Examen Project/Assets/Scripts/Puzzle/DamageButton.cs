using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the base class for all the puzzle buttons that need to react on taking damage.
/// </summary>
public class DamageButton : MonoBehaviour
{
    bool didTrigger = false;
    public virtual void TriggerOnDamage()
    {
        if (didTrigger == true)
            return;
        Debug.Log($"{name} got triggerd by damage");
    }
}
