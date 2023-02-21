using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public enum enemyState { Idle, Aggro, Attacking };

    public enemyState currentState { private set; get; }
    private NavMeshAgent agent;
    [SerializeField] Animator anim;

    [SerializeField] Enemy_Stats stats;
    private float _moveSpeed;
    private float _attackSpeed;
    private int _attackDamage;
    private LootTable _lootTable;
    private Health health;

    Vector3 previousPosition;
    Vector3 lastMoveDirection;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetCurrentState(enemyState.Idle);
        AssignStats();

        previousPosition = transform.position;
        lastMoveDirection = Vector3.zero;
    }

    private void FixedUpdate()
    {
        if (transform.position != previousPosition)
        {
            lastMoveDirection = (transform.position - previousPosition).normalized;
            previousPosition = transform.position;

            if (lastMoveDirection.x > 0.5f)
                anim.SetInteger("direction", 3);

            else if (lastMoveDirection.x < -0.5f)
                anim.SetInteger("direction", 4);

            if (lastMoveDirection.z > 0.5f)
                anim.SetInteger("direction", 2);

            else if (lastMoveDirection.z < -0.5f)
                anim.SetInteger("direction", 1);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player" || currentState == enemyState.Attacking)
            return;

        agent.SetDestination(other.transform.position);
    }

    public IEnumerator Attack(Collider player)
    {
print("Attack called");

        if (currentState == enemyState.Attacking)
            yield break;

        StartCoroutine(AttackCoolDown());
print("Attack start");

        SetCurrentState(enemyState.Attacking);
        yield return new WaitForEndOfFrame();

        //if (blocked)
        //{
        //  SetCurrentState(enemyState.Idle);
        //  yield break;
        //}
        player.GetComponent<Health>().DoDmg(_attackDamage);
        

print("Attack end");
    }

    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(_attackSpeed);
        SetCurrentState(enemyState.Idle);
    }

    public void SetCurrentState(enemyState state)
    {
        currentState = state;
    }

    private void AssignStats()
    {
        _moveSpeed = stats.getMoveSpeed();
        _attackSpeed = stats.getAttackSpeed();
        _attackDamage = stats.getAttackDamage();
        _lootTable = stats.getLootTable();

        health = GetComponent<Health>();
        health.maxHealth = stats.getMaxHealth();
    }

    public void OnDeath()
    {
        if (Random.Range(0, 101) > _lootTable.getLootChance())
            return;

        int newLootIndex = Random.Range(0, _lootTable.lootPrefabList.Length);
        GameObject newLoot = Instantiate(_lootTable.lootPrefabList[newLootIndex], transform.position, transform.rotation, null);

        Destroy(this);
    }


}
