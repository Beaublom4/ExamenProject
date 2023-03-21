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

        if (transform.tag == "Player")
        {
            HudManager.Instance.SetHealth(curHealth, maxHealth);
        }
            

    }

    private bool deathStarted = false;
    public void DoDmg(int dmg)
    {
        //take dmg from current health and check if health is lower or equels 0 if true play death animation.
        curHealth -= dmg;
        if (curHealth <= 0)
        {
            if (deathStarted)
                return;

            deathStarted = true;
            deathScript.OnDeath();
        }

        if (transform.tag == "Player")
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.red;
            HudManager.Instance.SetHealth(curHealth, maxHealth);
            StartCoroutine(playerColor());
        }
    }

    IEnumerator playerColor()
    {
        yield return new WaitForSeconds(.25f);
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
}
