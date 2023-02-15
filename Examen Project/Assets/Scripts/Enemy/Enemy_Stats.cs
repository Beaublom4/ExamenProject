using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "StatBlock", menuName = "EnemyStats")]
public class Enemy_Stats : ScriptableObject
{
    [SerializeField] float moveSpeed;
    [SerializeField] float attackSpeed;
    [SerializeField] int attackDamage;
    [SerializeField] int maxHealth;


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

}
