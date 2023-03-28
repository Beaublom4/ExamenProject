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
        if (isInteracted)
            return;
        else
            isInteracted = true;

        //Check if quest is already active and show thats active
        bool hasQuest = false;
        foreach(MessageHolder m in messages)
        {
            foreach(Message me in m.messages)
            {
                if (me.isQuest)
                    hasQuest = true;
            }
        }

        if (hasQuest && QuestManager.Instance.currentNPC != null && QuestManager.Instance.currentNPC != this)
        {
            DialogManager.Instance.AddMessageAndPlay(QuestManager.Instance.alreadyStartedQuestMessage, this, false);
            return;
        }

        //Check if quest active and has item
        Quest currentQuest = QuestManager.Instance.currentQuest;
        if (currentQuest != null)
            hasItem = InventoryManager.Instance.HasItem(currentQuest.questObjective, currentQuest.questCount);
        else
            questActive = false;

        if (!questActive)
        {
            //Display next message
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
            //Check for item en give message based on that
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
    public IEnumerator CanTalkAgain()
    {
        yield return new WaitForSecondsRealtime(.1f);
        isInteracted = false;
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
