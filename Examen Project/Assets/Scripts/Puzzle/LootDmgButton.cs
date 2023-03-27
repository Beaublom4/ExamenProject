using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Make sure that this object has a empty child or other way to assign the spawnpoint for the loot
/// </summary>

public class LootDmgButton : DamageButton
{
    [SerializeField] LootTable lootTable;
    [SerializeField] Transform lootSpawnPoint;

    bool didTrigger = false;
    public override void TriggerOnDamage()
    {
        if (didTrigger == true)
        {
            return;
        }

        didTrigger = true;
        base.TriggerOnDamage();
        Debug.Log("Loot Button overide triggerd!");

        int newLootIndex = Random.Range(0, lootTable.lootPrefabList.Length);
        GameObject newLoot = Instantiate(lootTable.lootPrefabList[newLootIndex], lootSpawnPoint.position, Quaternion.identity, null);
    }
}
