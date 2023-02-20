using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDmgButton : DamageButton
{
    public override void TriggerOnDamage()
    {
        base.TriggerOnDamage();
        Debug.Log("Event button override triggerd!");

        //run some event like a quest update or chance in a room
    }
}
