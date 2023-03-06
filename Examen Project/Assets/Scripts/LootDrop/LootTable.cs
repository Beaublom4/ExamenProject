using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_LootTable", menuName = "Stats/LootTable")]
public class LootTable : ScriptableObject
{
    public GameObject[] lootPrefabList;
    public GameObject coinPrefab;
    [Space]
    [Tooltip("The percentage chance of loot dropping")]
    [Range(0, 100)] [SerializeField] int lootChance;
    [Tooltip("Coins minimum and maximum drop")]
    [SerializeField] int minCoins, maxCoins;

    public int GetLootChance()
    {
        return lootChance;
    }
    public List<int> GetCoinCount()
    {
        return new() { minCoins, maxCoins };
    }
}
