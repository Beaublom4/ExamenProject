using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(Health), typeof(NavMeshAgent))]
public class EnemyBehavior : MonoBehaviour
{
    public enum enemyState { Idle, Aggro, Attacking, Dead };

    public enemyState currentState { private set; get; }

    private NavMeshAgent agent;
    private Animator anim;
    private EnemyDeath death;

    [SerializeField] Enemy_Stats stats;
    private float _attackSpeed;
    private int _attackDamage;
    private  Health health;
    [Tooltip("The amount of time the game should wait after starting the animtion before dealing damage")]
    [SerializeField] private float timeBeforeAttackDealsDamage;

    Vector3 previousPosition;
    Vector3 lastMoveDirection;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        death = GetComponentInChildren<EnemyDeath>();
        death.enemy = gameObject;


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
                anim.SetInteger("direction", 1);

            else if (lastMoveDirection.x < -0.5f)
                anim.SetInteger("direction", 1);

            if (lastMoveDirection.z > 0.5f)
                anim.SetInteger("direction", 2);

            else if (lastMoveDirection.z < -0.5f)
                anim.SetInteger("direction", 1);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player" || currentState != enemyState.Idle)
            return;

        agent.SetDestination(other.transform.position);
    }

    public IEnumerator Attack(Collider player)
    {

        if (currentState == enemyState.Attacking)
            yield break;

        anim.SetBool("attacking", true);
        StartCoroutine(AttackCoolDown());


        SetCurrentState(enemyState.Attacking);
        yield return new WaitForSeconds(timeBeforeAttackDealsDamage);

        //if (blocked)
        //{
        //  SetCurrentState(enemyState.Idle);
        //  yield break;
        //}
        player.GetComponent<Health>().DoDmg(_attackDamage);

    }

    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(_attackSpeed);

        anim.SetBool("attacking", false);
        SetCurrentState(enemyState.Idle);
    }

    public void SetCurrentState(enemyState state)
    {
        currentState = state;
    }

    private void AssignStats()
    {
        _attackSpeed = stats.getAttackSpeed();
        _attackDamage = stats.getAttackDamage();
        death._lootTable = stats.getLootTable();
        agent.speed = stats.getMoveSpeed();

        health = GetComponent<Health>();
        health.maxHealth = stats.getMaxHealth();
    }

    //public void StartDeath()
    //{
    //    anim.SetBool("death", true);
    //}

}
