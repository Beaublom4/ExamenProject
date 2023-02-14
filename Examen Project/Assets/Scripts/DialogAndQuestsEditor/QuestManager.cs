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
        questText.text += "<br>" + currentQuest.questObjective;
        questBox.SetActive(true);
    }
}
[System.Serializable]
public class Quest
{
    public Quest(string _questName, string _questObjective)
    {
        questName = _questName;
        questObjective = _questObjective;
    }

    public string questName;
    public string questObjective;
}