using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    public Quest[] quests;

    public GameObject questBox;
    public TMP_Text questText;

    public Message[] noQuestItemFoundMessage, questItemFoundMessage, alreadyStartedQuestMessage;


    public Quest currentQuest;
    public NPC currentNPC;

    private void Awake()
    {
        Instance = this;
    }
    /// <summary>
    /// Start a new quest
    /// </summary>
    /// <param name="_quest"></param>
    /// <param name="_npc"></param>
    public void StartQuest(Quest _quest, NPC _npc)
    {
        _npc.StartQuest();
        currentNPC = _npc;
        currentQuest = _quest;
        DisplayQuest();
    }
    /// <summary>
    /// Finish the current quest
    /// </summary>
    public void FinishQuest()
    {
        //Remove item from inventory
        //Add reward to player
        currentQuest = null;
        EmptyQuest();
    }
    /// <summary>
    /// Display the current quests titel and discription
    /// </summary>
    private void DisplayQuest()
    {
        questText.text = currentQuest.questName;
        questText.text += "<br>" + "Find: " + currentQuest.questObjective.itemName + " and return it";
        questBox.SetActive(true);
    }
    /// <summary>
    /// Clear current quest
    /// </summary>
    private void EmptyQuest()
    {
        questText.text = "";
        questBox.SetActive(false);

        currentQuest = null;
        currentNPC = null;
    }
}
[System.Serializable]
public class Quest
{
    public string questName;
    public ItemScrObj questObjective;
    public int questCount = 1;
    public int rewardCoins;
    public int rewardItem;
}