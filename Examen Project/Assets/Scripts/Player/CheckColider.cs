using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColider : MonoBehaviour
{
    public LayerMask all;
    private void Start()
    {

        Collider[] hitColiders = Physics.OverlapSphere(transform.position, 1, all, QueryTriggerInteraction.Ignore);
        foreach (var hitcoliders in hitColiders)
        {
            //check if the objects that the overlapSphere found have a Health or DamageButton scripts and call the right function.
            if(hitcoliders.GetComponent<Health>())
            {
                if(transform.tag == "Sword")
                    hitcoliders.GetComponent<Health>().DoDmg(InventoryManager.Instance.meleeSlot.item.meleeDamage);
            }
            else if(hitcoliders.GetComponent<DamageButton>())
            {
                hitcoliders.GetComponent<DamageButton>().TriggerOnDamage();
            }
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
