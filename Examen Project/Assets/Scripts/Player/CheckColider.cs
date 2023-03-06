using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().isTrigger)
            return;
        //check if the object that enterd the trigger has a Health or DamageButton scripts and call the right function.
        if(other.GetComponent<Health>())
        {
            if(transform.tag == "Sword")
                other.GetComponent<Health>().DoDmg(InventoryManager.Instance.meleeSlot.item.meleeDamage);
        }
        else if(other.GetComponent<DamageButton>())
        {
            other.GetComponent<DamageButton>().TriggerOnDamage();
        }
    }

    public void DestroyObj()
    {
        //destroys this gameobject called with a animation event.
        if(transform.tag == "Shield")
        {
            GetComponentInParent<PlayerCombat>().isShielding = false;
        }
        GetComponentInParent<PlayerMovement>().canMove = true;
        GetComponentInParent<PlayerCombat>().anim.SetBool("canMove", true);
        Destroy(this.gameObject);
    }
}
