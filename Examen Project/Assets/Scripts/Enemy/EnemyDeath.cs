using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : Death
{
    [HideInInspector] public GameObject enemy;
    [HideInInspector] public LootTable _lootTable;

    [Tooltip("The amount of time it takes for the death animtion to finish")]
    [SerializeField] private float animationWaitTime = 1f;


    public override void OnDeath()
    {
        base.OnDeath();
        enemy.GetComponent<EnemyBehavior>().SetCurrentState(EnemyBehavior.enemyState.Dead);
        StartCoroutine(WaitAndDestroy());
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(animationWaitTime);
        DropLoot();
        Destroy(enemy);
    }

    /// <summary>
    /// Checks a random number between 0 and 100, and if the random number is below the LootChance it will spawn a random loot item.
    /// Coins wil always spawn.
    /// </summary>
    void DropLoot()
    {
        //Get coin count
        int[] coinCount = _lootTable.GetCoinCount().ToArray();
        int coins = Random.Range(coinCount[0], coinCount[1] + 1);
        for (int i = 0; i < coins; i++)
        {
            //Instantiate coins and give force
            Vector3 spawnpoint = transform.position; spawnpoint.y += 1.5f; 
            GameObject newCoin = Instantiate(_lootTable.coinPrefab, spawnpoint, Quaternion.Euler(0, Random.Range(0, 360), 0));
            newCoin.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(1, 3, 0), ForceMode.Impulse);
        }

        if (Random.Range(0, 101) > _lootTable.GetLootChance())
            return;

        int newLootIndex = Random.Range(0, _lootTable.lootPrefabList.Length);
        GameObject newLoot = Instantiate(_lootTable.lootPrefabList[newLootIndex], transform.position, transform.rotation, null);

    }
}
