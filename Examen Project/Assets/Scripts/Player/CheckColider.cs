using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //check if the object that enterd the trigger has a Health or DamageButton scripts and call the right function.
        if(other.GetComponent<Health>())
        {
            other.GetComponent<Health>().takeHealth(5);
        }
        else if(other.GetComponent<DamageButton>())
        {
            other.GetComponent<DamageButton>().TriggerOnDamage();
        }
    }

    public void DestroyObj()
    {
        //destroys this gameobject called with a animation event.
        Destroy(this.gameObject);
    }
}
