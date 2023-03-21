using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject swordHitbox, swordPos, shieldObj, sideShieldObj, arrow, magicBall;
    private Vector3 newPos;
    private Vector3 swordRotation, shieldRotation, arrowRotation;
    public bool sideShieldBool, canAttack = true;
    public bool isShielding;

    [HideInInspector]public Animator anim;

    InventoryManager inventoryManager;

    private void Start()
    {
        // assigns inventoryManager and anim
        inventoryManager = InventoryManager.Instance;
        anim = GetComponentInChildren<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //check en set rotation of the sword attack.
        int dir = GetComponent<PlayerMovement>().direction;
        if (dir == 1)
        {
            newPos = new Vector3(0, 0, -0.5f);
            swordRotation = new Vector3(-90,0,0);
            shieldRotation = new Vector3(0,0,0);
            arrowRotation = new Vector3(90, 0, 0);
            sideShieldBool = false;
        }
        else if (dir == 2)
        {
            newPos = new Vector3(0, 0, 0.5f);
            swordRotation = new Vector3(90, 0, 0);
            shieldRotation = new Vector3(0, 0, 0);
            arrowRotation = new Vector3(180, 0, 0);
            sideShieldBool = false;
        }
        else if (dir == 3)
        {
            newPos = new Vector3(.75f, 0, 0);
            swordRotation = new Vector3(-90, 0, -90);
            shieldRotation = new Vector3(0, 180, 0);
            arrowRotation = new Vector3(90, -90, 0);
            sideShieldBool = true;
        }
        else if (dir == 4)
        {
            newPos = new Vector3(-.75f, 0, 0);
            swordRotation = new Vector3(90, 0, 90);
            shieldRotation = new Vector3(0, 0, 0);
            arrowRotation = new Vector3(90, 90, 0);
            sideShieldBool = true;
        }

        swordPos.transform.localPosition = newPos;
        if (canAttack)
        {
            //call swordAttack if you use the J button or call shieldblock if you use the H button.
            if (Input.GetButtonDown("Sword") && inventoryManager.meleeSlot.item != null)
            {
                canAttack = false;
                SwordAttack();
            }
            else if (Input.GetButtonDown("Shield") && inventoryManager.shieldSlot.item != null)
            {
                canAttack = false;
                ShieldBlock();
            }
            else if (Input.GetButtonDown("Bow") && inventoryManager.rangeSlot.item != null)
            {
                canAttack = false;
                BowAttack();
            }
            else if (Input.GetButtonDown("Magic") && inventoryManager.magicSlot.item != null)
            {
                canAttack = false;
                MagicAttack();
            }
        }
    }

    private void SwordAttack()
    {
        //Plays the animation, spawns the swordHitBox and starts the cooldown.
        anim.SetTrigger("swordAttack");
        anim.SetBool("canMove", false);
        Instantiate(swordHitbox, swordPos.transform.position, Quaternion.Euler(swordRotation), transform);
        StartCoroutine(AttackCooldown(inventoryManager.meleeSlot.item.meleeCooldown));
        GetComponent<PlayerMovement>().canMove = false;
    }
    private void BowAttack()
    {
        //Plays the animation, spawns the arrow and starts the cooldown.
        //anim.SetTrigger("swordAttack");
        Instantiate(arrow, swordPos.transform.position, Quaternion.Euler(arrowRotation));
        StartCoroutine(AttackCooldown(inventoryManager.rangeSlot.item.rangeCooldown));
    }
    private void MagicAttack()
    {
        //Plays the animation, spawns the maigcball and starts the cooldown.
        //anim.SetTrigger("swordAttack");
        Instantiate(magicBall, swordPos.transform.position, Quaternion.Euler(arrowRotation));
        StartCoroutine(AttackCooldown(inventoryManager.magicSlot.item.magicCooldown));
    }
    private void ShieldBlock()
    {
        isShielding = true;
        if (!sideShieldBool)
        {
            //Plays the animation, spawns the shieldObj and starts the cooldown.
            Instantiate(shieldObj, swordPos.transform.position, Quaternion.Euler(shieldRotation), transform);
            StartCoroutine(AttackCooldown(inventoryManager.shieldSlot.item.shieldCooldown));
            GetComponent<PlayerMovement>().canMove = false;
        }
        else
        {
            //Plays the animation, spawns the sideShieldObj and starts the cooldown.
            Instantiate(sideShieldObj, swordPos.transform.position, Quaternion.Euler(shieldRotation), transform);
            StartCoroutine(AttackCooldown(inventoryManager.shieldSlot.item.shieldCooldown));
            GetComponent<PlayerMovement>().canMove = false;
        }
    }

    IEnumerator AttackCooldown(float cooldown)
    {
        //waits for cooldown till player can attack or shield again.
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
}
