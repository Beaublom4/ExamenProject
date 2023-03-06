using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public void Death()
    {
        //makes it so the player cant move or attack and calls GameOver screen
        GetComponentInParent<PlayerMovement>().canMove = false;
        GetComponentInParent<PlayerCombat>().canAttack = false;
        HudManager.Instance.GameOver();
    }
}
