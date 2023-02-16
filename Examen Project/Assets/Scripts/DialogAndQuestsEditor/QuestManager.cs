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

    public Message[] noQuestItemFoundMessage, questItemFoundMessage;


    private Quest currentQuest;

    private void Awake()
    {
        Instance = this;
    }
    public void StartQuest(Quest _quest, NPC _npc)
    {
        _npc.StartQuest();
        currentQuest = _quest;
        DisplayQuest();
    }
    public void FinishQuest()
    {
        //Remove item from inventory
        //Add reward to player
        currentQuest = null;
        EmptyQuest();
    }
    private void DisplayQuest()
    {
        questText.text = currentQuest.questName;
        questText.text += "<br>" + "Find: " + currentQuest.questObjective.itemName + " and return it";
        questBox.SetActive(true);
    }
    private void EmptyQuest()
    {
        questText.text = "";
        questBox.SetActive(false);
    }
}
[System.Serializable]
public class Quest
{
    public string questName;
    public ItemScrObj questObjective;
}