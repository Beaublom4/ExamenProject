using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public MessageHolder[] messages;
    int currentMessages = 0;

    public Animator anim;

    private bool questActive;
    public bool hasItem;

    [ContextMenu("Interact")]
    public void Interact()
    {
        //TODO: Check if the npc has more messages, and check for more quests

        //turn off movement
        if (!questActive)
        {
            if (currentMessages >= messages.Length)
            {
                DialogManager.Instance.AddMessageAndPlay(DialogManager.Instance.dontHaveAnythingMessages, this);
            }
            else
            {
                DialogManager.Instance.AddMessageAndPlay(messages[currentMessages].messages, this);
            }
        }
        else
        {
            if (hasItem)
            {
                QuestManager.Instance.FinishQuest();
                DialogManager.Instance.AddMessageAndPlay(QuestManager.Instance.questItemFoundMessage, this);
                currentMessages++;
                questActive = false;
                hasItem = false;
            }
            else
            {
                DialogManager.Instance.AddMessageAndPlay(QuestManager.Instance.noQuestItemFoundMessage, this);
            }
        }
    }
    public void StartQuest()
    {
        questActive = true;
    }
}
[System.Serializable]
public class MessageHolder
{
    public Message[] messages = new Message[0];
}
