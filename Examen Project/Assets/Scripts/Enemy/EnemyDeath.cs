using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [HideInInspector] public GameObject enemy;
    [HideInInspector] public LootTable _lootTable;

    public void OnDeath()
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

        Destroy(enemy);
    }
}
