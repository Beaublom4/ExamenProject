using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : Death
{
    [HideInInspector] public GameObject enemy;
    [HideInInspector] public LootTable _lootTable;

    [Tooltip("The amount of time it takes for the death animtion to finish")]
    [SerializeField] private float animationWaitTime;

    //public bool pijn = false;

    public override void OnDeath()
    {
        //if (pijn)
        //{
        //    return;
        //}
        //pijn = true;

        Debug.Log("-- Died Start");
        base.OnDeath();

        enemy.GetComponent<EnemyBehavior>().SetCurrentState(EnemyBehavior.enemyState.Dead);

        DropLoot();

        Debug.Log("-- Died END");
        Destroy(enemy);
    }

    void DropLoot()
    {
        if (Random.Range(0, 101) > _lootTable.GetLootChance())
            return;

        int newLootIndex = Random.Range(0, _lootTable.lootPrefabList.Length);
        GameObject newLoot = Instantiate(_lootTable.lootPrefabList[newLootIndex], transform.position, transform.rotation, null);

        //Get coin count
        int[] coinCount = _lootTable.GetCoinCount().ToArray();
        int coins = Random.Range(coinCount[0], coinCount[1] + 1);
        for (int i = 0; i < coins; i++)
        {
            //Instantiate coins and give force
            GameObject newCoin = Instantiate(_lootTable.coinPrefab, transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0));
            newCoin.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(1, 3, 0), ForceMode.Impulse);
        }
    }
}
