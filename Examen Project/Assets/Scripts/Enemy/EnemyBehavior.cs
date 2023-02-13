using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;
    private enum state {Idle, Aggro, Attacking};

    private state currentState = state.Idle;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            currentState = state.Aggro;
        }
    }

    private void LateUpdate()
    {
        if (currentState == state.Aggro)
        {
            agent.SetDestination(playerTransform.position);
        }
    }

}
