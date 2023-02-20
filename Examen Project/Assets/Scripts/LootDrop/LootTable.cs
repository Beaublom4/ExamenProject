using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_LootTable", menuName = "Stats/LootTable")]
public class LootTable : ScriptableObject
{
    public GameObject[] lootPrefabList;
    [Tooltip("The percentage chance of loot dropping")]
    [Range(0, 100)] [SerializeField] int lootChance;

    public int getLootChance()
    {
        return lootChance;
    }
}
