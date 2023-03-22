using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is to be placed on a child object of the enemy.
/// This object should have a trigger to start the attack.
/// </summary>

[RequireComponent(typeof(Collider))]
public class EnemyAttackRangeFinder : MonoBehaviour
{
    EnemyBehavior thisEnemy;
    
    private void Awake()
    {
        thisEnemy = GetComponentInParent<EnemyBehavior>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(thisEnemy.Attack(other));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            thisEnemy.playerIsInAttackRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            thisEnemy.playerIsInAttackRange = false;
        }
    }
}
