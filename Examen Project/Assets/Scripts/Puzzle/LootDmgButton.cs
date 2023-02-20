using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDmgButton : DamageButton
{
    [SerializeField] LootTable lootTable;
    [SerializeField] Transform lootSpawnPoint;

    public override void TriggerOnDamage()
    {
        base.TriggerOnDamage();
        Debug.Log("Loot Button overide triggerd!");

        int newLootIndex = Random.Range(0, lootTable.lootPrefabList.Length);
        GameObject newLoot = Instantiate(lootTable.lootPrefabList[newLootIndex], transform.position, transform.rotation, null);
    }
}
