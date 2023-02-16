using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    public float messageSpeed;

    public Message[] dontHaveAnythingMessages;

    public GameObject messageBox;
    public GameObject continueButton;
    public GameObject[] questButtons;

    private Quest quest;

    public TMP_Text messageText;
    private string currentDisplayingMessage;
    private bool typingMessage;

    public List<Message> messages = new();

    private NPC currentNpc;

    private void Awake()
    {
        Instance = this;
    }
    public void AddMessageAndPlay(Message _message)
    {
        messages.Add(_message);
        if (!typingMessage)
        {
            messageBox.SetActive(true);
            StartDisplayingMessages();
        }
    }
    public void AddMessageAndPlay(Message[] _messages, NPC _npc)
    {
        currentNpc = _npc;
        foreach (Message m in _messages)
        {
            AddMessageAndPlay(m);
        }
    }

    IEnumerator DislayMessage(Message _message)
    {
        typingMessage = true;
        messageText.maxVisibleCharacters = 0;

        currentDisplayingMessage = _message.message;
        messageText.text = _message.message;

        while (messageText.maxVisibleCharacters < _message.message.Length)
        {
            messageText.maxVisibleCharacters++;
            yield return new WaitForSeconds(messageSpeed);
        }

        if (_message.isQuest)
        {
            quest = _message.quest;
            QuestButtons(true);
        }

        typingMessage = false;
    }
    
    public void StartDisplayingMessages()
    {
        StartCoroutine(DislayMessage(messages[0]));
    }
    public void ContinueMessage()
    {
        currentDisplayingMessage = "";
        if (messageText.maxVisibleCharacters < currentDisplayingMessage.Length)
        {
            messageText.maxVisibleCharacters = currentDisplayingMessage.Length;
        }
        else
        {
            messages.RemoveAt(0);
            if(messages.Count > 0)
                StartDisplayingMessages();
            else messageBox.SetActive(false);
        }
    }
    public void AcceptQuest()
    {
        QuestManager.Instance.StartQuest(quest, currentNpc);

        QuestButtons(false);
        ContinueMessage();
    }
    public void DenyQuest()
    {
        QuestButtons(false);
        ContinueMessage();
    }

    public void QuestButtons(bool b)
    {
        continueButton.SetActive(!b);
        foreach (GameObject g in questButtons)
            g.SetActive(b);
    }
}
[System.Serializable]
public class Message
{
    public Message(string _message, bool _isQuest, Quest _quest)
    {
        message = _message;
        isQuest = _isQuest;
        quest = _quest;
    }
    public Message(string _message, bool _isQuest)
    {
        message = _message;
        isQuest = _isQuest;
    }

    public string message;
    public bool isQuest;
    public Quest quest;
}
