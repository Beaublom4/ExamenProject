using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public float OverlapRadius;
    public Vector3 raycastDir;
    public GameObject overlapPos;
    public AudioClip pickUp;

    // Update is called once per frame
    void Update()
    {
        //makes the overlapsphere face the direction the player is facing.
        Vector3 move = GetComponent<PlayerMovement>().movement;
        if (move.x > 0)
            raycastDir = new Vector3(1, 0, 0);
        else if (move.x < 0)
            raycastDir = new Vector3(-1, 0, 0);
        else if (move.z > 0)
            raycastDir = new Vector3(0, 0, 1);
        else if (move.z < 0)
            raycastDir = new Vector3(0, 0, -1);

        //cast a overlapSphere and assigns all colliders to hitcoll.
        Collider[] hitColl = Physics.OverlapSphere(overlapPos.transform.position, OverlapRadius);
        //checks each collider in hitcoll for a tag matching NPC Puzzel or Shop and calls the right functions.
        print(Input.GetJoystickNames().Length);
        if(Input.GetJoystickNames().Length != 0)
        {
            for (int i = 0; i < hitColl.Length; i++)
            {
                if (hitColl[i].transform.tag == "NPC")
                {
                    GetComponent<PlayerCombat>().stopAttack = true;
                    break;
                }
                else if (hitColl[i].transform.tag == "Puzzel")
                {
                    GetComponent<PlayerCombat>().stopAttack = true;
                    break;
                }
                else if (hitColl[i].transform.tag == "Shop")
                {
                    GetComponent<PlayerCombat>().stopAttack = true;
                    break;
                }
                else
                    GetComponent<PlayerCombat>().stopAttack = false;
            }
        }
        if(Input.GetButtonDown("InteractionKey"))
            foreach (var hit in hitColl)
            {
                if (hit.transform.tag == "NPC")
                {
                    hit.transform.GetComponent<NPC>().Interact();
                }
                else if (hit.transform.tag == "Puzzel")
                {
                    if (hit.transform.GetComponent<PushPuzzel>().complete == false)
                    {
                        GetComponent<PlayerMovement>().isPushing = true;
                        hit.transform.GetComponent<PushPuzzel>().SelectedPuzzel(transform);
                    }
                }
                else if (hit.transform.tag == "Shop")
                {
                    hit.transform.GetComponent<ShopNPC>().OpenShop();
                }
            }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //picks up the item or coin and cakks the right function.
        if (collision.transform.tag == "Item")
        {
            var item = collision.transform.GetComponent<Item>();
            if(item.doPopup)
            {
                PopupManager.Instance.NewRoutine(item.popupObj, null);
                SoundManager.Instance.PlaySound(pickUp, 1);
            }
            item.PickUpItem();
        }
        if (collision.transform.tag == "Coin")
        {
            InventoryManager.Instance.AddCoin(collision.gameObject);
            SoundManager.Instance.PlaySound(pickUp, 1);
        }
    }
}
