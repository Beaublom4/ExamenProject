using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRangeFinder : MonoBehaviour
{
    EnemyBehavior thisEnemy;

    private void Awake()
    {
        GetComponentInParent<EnemyBehavior>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(thisEnemy.Attack());
        }
    }
}
