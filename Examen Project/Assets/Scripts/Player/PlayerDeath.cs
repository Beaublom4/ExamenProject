using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : Death
{
    public override void OnDeath()
    {
        base.OnDeath();
    }

    public void AnimationDone()
    {
        Debug.Log("Player animation done!");
        //makes it so the player cant move or attack and calls GameOver screen
        GetComponentInParent<PlayerMovement>().canMove = false;
        GetComponentInParent<PlayerCombat>().canAttack = false;
        HudManager.Instance.GameOver();
        Time.timeScale = 0;
    }
}
