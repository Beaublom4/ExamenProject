using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is to be placed on a child object of the enemy.
/// This object should have a trigger to start the attack.
/// </summary>

public class EnemyAttackRangeFinder : MonoBehaviour
{
    public EnemyBehavior thisEnemy;

    private void Awake()
    {
        thisEnemy = GetComponentInParent<EnemyBehavior>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(thisEnemy.Attack());
        }
    }
}
