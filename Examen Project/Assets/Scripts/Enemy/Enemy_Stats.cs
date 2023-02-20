using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is used to assign stats to enemys.
/// Create a statblock through the create asset menu.
/// Assign the values as you like and assign the statblock to any enemy prefab as you see fit.
/// </summary>

[CreateAssetMenu(fileName = "StatBlock", menuName = "Stats/EnemyStats")]
public class Enemy_Stats : ScriptableObject
{
    [Tooltip("The speed at which the enemy moves")]
    [SerializeField] float moveSpeed = 1f;

    [Tooltip("Delay between attacks in seconds")]
    [SerializeField] float attackSpeed = 1f;

    [Tooltip("The amount of health the player will lose when hit")]
    [SerializeField] int attackDamage = 1;

    [Tooltip("The total health this enemy will have")]
    [SerializeField] int maxHealth = 1;

    [Tooltip("The lootTable that is used for item drops")]
    [SerializeField] LootTable lootTable;
    

    public float getMoveSpeed()
    {
        return moveSpeed;
    }
    public float getAttackSpeed()
    {
        return attackSpeed;
    }
    public int getAttackDamage()
    {
        return attackDamage;
    }
    public int getMaxHealth()
    {
        return maxHealth;
    }
    public LootTable getLootTable()
    {
        return lootTable;
    }

}
