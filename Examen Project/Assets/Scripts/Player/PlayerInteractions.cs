using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public float RayRange;
    public Vector3 raycastDir;

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
            //set all parameters for raycast.
            Vector3 playerPos = transform.position;

            Ray interactrionRay = new Ray(playerPos, raycastDir);
            RaycastHit interactionRayHit;

            //checks the tag of the object that the raycast hit and calls the right function.
            if (Physics.Raycast(interactrionRay, out interactionRayHit, RayRange))
            {
                if (interactionRayHit.transform.tag == "NPC")
                {
                    interactionRayHit.transform.GetComponent<NPC>().Interact();
                    print("NPC True");
                }
                if (interactionRayHit.transform.tag == "Puzzel")
                {
                    print("Puzzel True");
                }
                if (interactionRayHit.transform.tag == "Item")
                {
                    print("Item True");
                }
                if (interactionRayHit.transform.tag == "Shop")
                {
                    print("Shop True");
                }
            }

        }
    }
}
