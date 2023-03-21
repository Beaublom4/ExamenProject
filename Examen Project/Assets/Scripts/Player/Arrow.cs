using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float arrowSpeed;
    public LayerMask all;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * arrowSpeed * Time.deltaTime);

        Collider[] hitColiders = Physics.OverlapSphere(transform.position, .5f, all, QueryTriggerInteraction.Ignore);
        foreach (var hitcoliders in hitColiders)
        {
            print(hitcoliders.name);
            //check if the objects that the overlapSphere found have a Health or DamageButton scripts and call the right function.
            if (hitcoliders.GetComponent<Health>())
            {
                if (transform.tag == "Arrow")
                    hitcoliders.GetComponent<Health>().DoDmg((int)InventoryManager.Instance.rangeSlot.item.rangeDamage);
            }
            DestroyObj();
        }
    }

    public void DestroyObj()
    {
        //destroys this gameobject called when arrow hits a object.
        Destroy(this.gameObject);
    }
}
