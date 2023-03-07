using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public float OverlapRadius;
    public Vector3 raycastDir;
    public GameObject overlapPos;

    // Update is called once per frame
    void Update()
    {
        //makes the raycast face the direction the player is facing.
        Vector3 move = GetComponent<PlayerMovement>().movement;
        if (move.x > 0)
            raycastDir = new Vector3(1, 0, 0);
        else if (move.x < 0)
            raycastDir = new Vector3(-1, 0, 0);
        else if (move.z > 0)
            raycastDir = new Vector3(0, 0, 1);
        else if (move.z < 0)
            raycastDir = new Vector3(0, 0, -1);

        if (Input.GetButtonDown("InteractionKey"))
        {
            //cast a overlapSphere and assigns all colliders to hitcoll.
            Collider[] hitColl = Physics.OverlapSphere(overlapPos.transform.position, OverlapRadius);

            //checks each collider in hitcoll for a tag matching NPC Puzzel or Shop and calls the right functions.
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
                        transform.position = hit.transform.GetChild(0).position;
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        //picks up the item or coin.
        if (collision.transform.tag == "Item")
        {
            collision.transform.GetComponent<Item>().PickUpItem();
        }
        if (collision.transform.tag == "Coin")
        {
            InventoryManager.Instance.AddCoin(collision.gameObject);
        }
    }
}
