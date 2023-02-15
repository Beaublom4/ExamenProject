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

    private Quest currentQuest;

    private void Awake()
    {
        Instance = this;
    }
    public void SetQuest(Quest _quest)
    {
        currentQuest = _quest;
        DisplayQuest();
    }
    private void DisplayQuest()
    {
        questText.text = currentQuest.questName;
        questText.text += "<br>" + "Find: " + currentQuest.questObjective.itemName + " and return it";
        questBox.SetActive(true);
    }
}
[System.Serializable]
public class Quest
{
    public string questName;
    public ItemScrObj questObjective;
}