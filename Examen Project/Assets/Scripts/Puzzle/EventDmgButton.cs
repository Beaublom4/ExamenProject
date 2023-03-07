using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDmgButton : DamageButton
{
    public GameObject[] rewards;


    public override void TriggerOnDamage()
    {
        base.TriggerOnDamage();

        foreach (var reward in rewards)
        {
            reward.SetActive(!reward.activeSelf);
        }
    }
}
