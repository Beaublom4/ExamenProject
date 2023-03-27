using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Make sure that this object has a empty child or other way to assign the spawnpoint for the loot
/// </summary>

public class LootPPlate : PressurePlate
{
    [SerializeField] LootTable lootTable;
    [SerializeField] Transform lootSpawnPoint;
    public override IEnumerator CheckPressure()
    {
        if (didTrigger == true)
        {
            yield break;
        }

        didTrigger = true;
        base.CheckPressure();

        int newLootIndex = Random.Range(0, lootTable.lootPrefabList.Length);
        GameObject newLoot = Instantiate(lootTable.lootPrefabList[newLootIndex], lootSpawnPoint.position, Quaternion.identity, null);


        checkPressureIsRunning = false;
        yield return null;
    }
}
