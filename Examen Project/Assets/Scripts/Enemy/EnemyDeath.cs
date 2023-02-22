using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [HideInInspector] public GameObject enemy;
    [HideInInspector] public LootTable _lootTable;
    public void OnDeath()
    {
        if (Random.Range(0, 101) > _lootTable.getLootChance())
            return;

        int newLootIndex = Random.Range(0, _lootTable.lootPrefabList.Length);
        GameObject newLoot = Instantiate(_lootTable.lootPrefabList[newLootIndex], transform.position, transform.rotation, null);

        Destroy(enemy);
    }
}
