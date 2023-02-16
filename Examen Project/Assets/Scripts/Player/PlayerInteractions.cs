using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public float RayRange;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("InteractionKey"))
        {
            print("test1");
            Vector3 playerPos = transform.position;
            Vector3 dir = transform.forward;

            Ray interactrionRay = new Ray(playerPos, dir);
            RaycastHit interactionRayHit;

            Debug.DrawRay(playerPos, dir, Color.black, 10f);

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
            }

        }
    }
}
