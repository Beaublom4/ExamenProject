using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;
    public enum enemyState {Idle, Aggro, Attacking};

    private enemyState currentState = enemyState.Idle;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentState == enemyState.Attacking)
            return;

        if (other.tag == "Player")
            SetCurrentState(enemyState.Aggro);
    }

    public IEnumerator Attack()
    {
        SetCurrentState(enemyState.Attacking);

        ///Physics.OverlapSphere(); or other hitbox spawn to detect player
        ///do damage if not blocked
        
        yield return new WaitForSeconds(0.5f);
    }

    public void SetCurrentState(enemyState state)
    {
        currentState = state;
    }

    private void LateUpdate()
    {
        if (currentState == enemyState.Aggro)
        {
            agent.SetDestination(playerTransform.position);
        }
    }

}
