using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(Health), typeof(NavMeshAgent))]
public class EnemyBehavior : MonoBehaviour
{
    public enum enemyState { Idle, Attacking, Dead };

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
        // Checks if the current position and comparais it to the last one if they aren't the same it will update what animation is being used. 
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

        if (currentState == enemyState.Attacking || currentState == enemyState.Dead)
            yield break;

        anim.SetBool("attacking", true);
        SetCurrentState(enemyState.Attacking);
        StartCoroutine(AttackCoolDown());


        yield return new WaitForSeconds(timeBeforeAttackDealsDamage);

        if (currentState == enemyState.Dead)
        {
            Debug.Log("No longer in attacking state damage stopped!");
            yield break;
        }
            

        if (player.GetComponent<PlayerCombat>().isShielding)
        {
            SetCurrentState(enemyState.Idle);
            yield break;
        }

        player.GetComponent<Health>().DoDmg(_attackDamage);

    }

    /// <summary>
    /// This makes the enemy wait before chasing and attacking the player again based on the _attackSpeed value.
    /// </summary>
    /// <returns></returns>
    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(_attackSpeed);

        anim.SetBool("attacking", false);
        SetCurrentState(enemyState.Idle);
    }

    /// <summary>
    /// The state chance is done through a function so that there is the potential to prevent a state change in specific situations.
    /// </summary>
    /// <param name="state"></param>
    public void SetCurrentState(enemyState state)
    {
        if (currentState == enemyState.Dead)
            return;

        Debug.Log($"[STATE UPDATE] {currentState} > {state}");
        currentState = state;
    }

    /// <summary>
    /// Cashes all the info from the stats. Should be called at the Start.
    /// </summary>
    private void AssignStats()
    {
        _attackSpeed = stats.getAttackSpeed();
        _attackDamage = stats.getAttackDamage();
        death._lootTable = stats.getLootTable();
        agent.speed = stats.getMoveSpeed();

        health = GetComponent<Health>();
        health.maxHealth = stats.getMaxHealth();
    }
}
