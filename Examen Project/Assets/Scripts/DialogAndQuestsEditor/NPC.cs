using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Message[] messages = new Message[0];

    [ContextMenu("Interact")]
    public void Interact()
    {
        //turn off movement
        DialogManager.Instance.AddMessageAndPlay(messages);
    }
}
