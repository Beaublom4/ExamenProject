using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Animator anim;
    public MessageHolder[] messages;
    public int currentMessages = 0;


    private bool questActive;
    [HideInInspector] public bool isInteracted;
    private bool hasItem;

    private void Start()
    {
        if (messages[currentMessages].onStartActivate)
        {
            Interact();
        }
        else if (messages[currentMessages].triggerActivate)
        {
            messages[currentMessages].trigger.npc = this;
        }
    }
    /// <summary>
    /// Intracts with the npc to start the conversation
    /// </summary>
    [ContextMenu("Interact")]
    public void Interact()
    {
        //Check if quest is already active
        if (QuestManager.Instance.currentNPC != null && QuestManager.Instance.currentNPC != this)
        {
            DialogManager.Instance.AddMessageAndPlay(QuestManager.Instance.alreadyStartedQuestMessage, this, false);
            return;
        }

        if (isInteracted)
            return;
        else
            isInteracted = true;

        Quest currentQuest = QuestManager.Instance.currentQuest;
        if (currentQuest != null)
            hasItem = InventoryManager.Instance.HasItem(currentQuest.questObjective, currentQuest.questCount);
        else
            questActive = false;

        if (!questActive)
        {
            if (currentMessages >= messages.Length)
            {
                DialogManager.Instance.AddMessageAndPlay(DialogManager.Instance.dontHaveAnythingMessages, this, false);
            }
            else
            {
                DialogManager.Instance.AddMessageAndPlay(messages[currentMessages].messages, this, true);
            }
        }
        else
        {
            if (hasItem)
            {
                InventoryManager.Instance.RemoveItem(QuestManager.Instance.currentQuest.questObjective, currentQuest.questCount);
                QuestManager.Instance.FinishQuest();
                DialogManager.Instance.AddMessageAndPlay(QuestManager.Instance.questItemFoundMessage, this, false);
                currentMessages++;
                questActive = false;
                hasItem = false;
            }
            else
            {
                DialogManager.Instance.AddMessageAndPlay(QuestManager.Instance.noQuestItemFoundMessage, this, false);
            }
        }
    }
    /// <summary>
    /// Start the quest on npc
    /// </summary>
    public void StartQuest()
    {
        questActive = true;
    }
}
[System.Serializable]
public class MessageHolder
{
    public Message[] messages = new Message[0];
    [Space]
    public bool triggerActivate;
    public TriggerDialog trigger;
    [Space]
    public bool onStartActivate;
}
