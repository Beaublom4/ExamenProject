using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject swordHitbox, swordPos, shieldObj, sideShieldObj;
    private Vector3 newPos;
    private Vector3 swordRotation, shieldRotation;
    public bool sideShieldBool, canAttack = true;
    public bool isShielding;

    public Animator anim;

    InventoryManager inventoryManager;

    private void Start()
    {
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
            sideShieldBool = false;
        }
        else if (dir == 2)
        {
            newPos = new Vector3(0, 0, 0.5f);
            swordRotation = new Vector3(90, 0, 0);
            shieldRotation = new Vector3(0, 0, 0);
            sideShieldBool = false;
        }
        else if (dir == 3)
        {
            newPos = new Vector3(.75f, 0, 0);
            swordRotation = new Vector3(-90, 0, -90);
            shieldRotation = new Vector3(0, 180, 0);
            sideShieldBool = true;
        }
        else if (dir == 4)
        {
            newPos = new Vector3(-.75f, 0, 0);
            swordRotation = new Vector3(90, 0, 90);
            shieldRotation = new Vector3(0, 0, 0);
            sideShieldBool = true;
        }

        swordPos.transform.localPosition = newPos;
        if (canAttack)
        {
            //call swordAttack if you use the J button.
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
        }
    }

    private void SwordAttack()
    {
        //spawn the swordHitBox.
        anim.SetTrigger("swordAttack");
        anim.SetBool("canMove", false);
        Instantiate(swordHitbox, swordPos.transform.position, Quaternion.Euler(swordRotation), swordPos.transform);
        StartCoroutine(AttackCooldown(inventoryManager.meleeSlot.item.meleeCooldown));
        GetComponent<PlayerMovement>().canMove = false;
    }
    private void ShieldBlock()
    {
        isShielding = true;
        if (!sideShieldBool)
        {
            //spawn the shieldObj.
            Instantiate(shieldObj, swordPos.transform.position, Quaternion.Euler(shieldRotation), swordPos.transform);
            StartCoroutine(AttackCooldown(inventoryManager.shieldSlot.item.shieldCooldown));
            GetComponent<PlayerMovement>().canMove = false;
        }
        else
        {
            //spawn the sideShieldObj.
            Instantiate(sideShieldObj, swordPos.transform.position, Quaternion.Euler(shieldRotation), swordPos.transform);
            StartCoroutine(AttackCooldown(inventoryManager.shieldSlot.item.shieldCooldown));
            GetComponent<PlayerMovement>().canMove = false;
        }
    }

    IEnumerator AttackCooldown(float cooldown)
    {
        //waits for cooldown till player can attack again.
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
}
