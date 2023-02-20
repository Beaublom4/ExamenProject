using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth, curHealth;

    public void addHealth(int addNum)
    {
        //add addNum to current health en check if higher than maxhealth if higher set to maxhealth.
        curHealth += addNum;
        if (curHealth > maxHealth)
            curHealth = maxHealth;
    }
    public void takeHealth(int dmg)
    {
        //take dmg from current health and check if health is lower or equels 0 if true call die.
        curHealth -= dmg;
        if (curHealth <= 0)
            die();
    }
    public void die()
    {
        //die
        print("DIE");
    }


}
