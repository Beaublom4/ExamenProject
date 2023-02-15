using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public enum enemyState {Idle, Aggro, Attacking};
    
    private enemyState currentState = enemyState.Idle;
    private NavMeshAgent agent;
    private Transform playerTransform;

    public Enemy_Stats _Stats;

    public GameObject[] lootPrefabList;
    [Range(0, 100)]public int lootChange;

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

    [ContextMenu("loot")]
    public void OnDeath()
    {
        if (Random.Range(0, 101) > lootChange)
            return;

        int newLootIndex = Random.Range(0, lootPrefabList.Length);
        GameObject newLoot = Instantiate(lootPrefabList[newLootIndex], transform.position, transform.rotation, null);
    }

    private void LateUpdate()
    {
        if (currentState == enemyState.Aggro)
        {
            agent.SetDestination(playerTransform.position);
        }
    }

}
