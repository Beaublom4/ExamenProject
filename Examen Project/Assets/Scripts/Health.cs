using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [HideInInspector]public int maxHealth, curHealth;
    public Death deathScript;

    private void Start()
    {
        //set player health en zet current health same as max health.
        if (transform.tag == "Player")
            maxHealth = 10;
        curHealth = maxHealth;
    }

    public void addHealth(int addNum)
    {
        //add addNum to current health en check if higher than maxhealth if higher set to maxhealth.
        curHealth += addNum;
        if (curHealth > maxHealth)
            curHealth = maxHealth;

        if (CompareTag("Player"))
            HudManager.Instance.SetHealth(curHealth, maxHealth);

    }
    public void DoDmg(int dmg)
    {
        //take dmg from current health and check if health is lower or equels 0 if true play death animation.
        curHealth -= dmg;
        if (curHealth <= 0)
        {
            deathScript.OnDeath();
        }
            
        HudManager.Instance.SetHealth(curHealth, maxHealth);
    }
}
