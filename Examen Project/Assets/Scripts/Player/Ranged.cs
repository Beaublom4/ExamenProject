using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : MonoBehaviour
{
    public float arrowSpeed, radius;
    public LayerMask all;
    private bool canMove = true;
    private Vector3 startDist;

    public AudioClip boom;

    private void Start()
    {
        startDist = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if(canMove)
            transform.Translate(transform.forward * arrowSpeed * Time.deltaTime);

        if (transform.tag == "Magic")
            if (Vector3.Distance(startDist, transform.position) > 2)
                StartCoroutine(delayMagicDestroy(.5f));

        Collider[] hitColiders = Physics.OverlapSphere(transform.position, radius, all, QueryTriggerInteraction.Ignore);
        foreach (var hitcoliders in hitColiders)
        {
            print(hitcoliders.name);
            //check if the objects that the overlapSphere found have a Health or DamageButton scripts and call the right function.
            if (hitcoliders.GetComponent<Health>())
            {
                if (transform.tag == "Arrow")
                    hitcoliders.GetComponent<Health>().DoDmg((int)InventoryManager.Instance.rangeSlot.item.rangeDamage);
                if (transform.tag == "Magic")
                    hitcoliders.GetComponent<Health>().DoDmg((int)InventoryManager.Instance.magicSlot.item.magicDamage);
            }
            if (transform.tag == "Magic")
            {
                StartCoroutine(delayMagicDestroy(.5f));
            }
            else
                DestroyObj();
        }
    }

    IEnumerator delayMagicDestroy(float delay)
    {
        SoundManager.Instance.PlaySound(boom, .5f);
        canMove = false;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        radius = 4;
        yield return new WaitForSeconds(delay);
        DestroyObj();
    }

    public void DestroyObj()
    {
        //destroys this gameobject called when arrow hits a object.
        Destroy(this.gameObject);
    }
}
