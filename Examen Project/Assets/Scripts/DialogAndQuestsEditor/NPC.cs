using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public MessageHolder[] messages;
    int currentMessages = 0;

    public Animator anim;

    private bool questActive;
    public bool isInteracted;
    public bool hasItem;

    [ContextMenu("Interact")]
    public void Interact()
    {
        if (isInteracted)
            return;
        else
            isInteracted = true;

        FindObjectOfType<PlayerMovement>().canMove = false;

        Quest currentQuest = QuestManager.Instance.currentQuest;
        if (currentQuest != null)
            hasItem = InventoryManager.Instance.HasItem(currentQuest.questObjective, currentQuest.questCount);
        else
            questActive = false;

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
                InventoryManager.Instance.RemoveItem(QuestManager.Instance.currentQuest.questObjective, currentQuest.questCount);
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
