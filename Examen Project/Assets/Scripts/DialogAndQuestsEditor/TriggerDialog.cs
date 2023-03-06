using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialog : MonoBehaviour
{
    [HideInInspector] public NPC npc;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            if(npc != null)
            {
                npc.Interact();
                Destroy(gameObject);
            }
        }
    }
}
