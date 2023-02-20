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

    //Set instance
    private void Awake()
    {
        Instance = this;
    }
    /// <summary>
    /// Add a message to the list of messages, and play if its not yet playing
    /// </summary>
    /// <param name="_message"></param>
    public void AddMessageAndPlay(Message _message)
    {
        messages.Add(_message);
        if (!typingMessage)
        {
            messageBox.SetActive(true);
            StartDisplayingMessages();
        }
    }
    /// <summary>
    /// Add messages as array to the list of messages, and play if its not yet playing
    /// </summary>
    /// <param name="_messages"></param>
    /// <param name="_npc"></param>
    public void AddMessageAndPlay(Message[] _messages, NPC _npc)
    {
        currentNpc = _npc;
        foreach (Message m in _messages)
        {
            AddMessageAndPlay(m);
        }
    }

    //Routine of messages playing
    IEnumerator DislayMessage(Message _message)
    {
        typingMessage = true;
        messageText.maxVisibleCharacters = 0;
        currentNpc.anim.SetBool("talking", true);

        currentDisplayingMessage = _message.message;
        messageText.text = _message.message;

        //Displaying message 1 char for 1 char
        while (messageText.maxVisibleCharacters < _message.message.Length)
        {
            messageText.maxVisibleCharacters++;
            yield return new WaitForSeconds(messageSpeed);
        }
        //Check if current message has a quest connected
        if (_message.isQuest)
        {
            quest = _message.quest;
            QuestButtons(true);
        }

        typingMessage = false;
        currentNpc.anim.SetBool("talking", false);
    }
    /// <summary>
    /// Start coroutine from here (public)
    /// </summary>
    public void StartDisplayingMessages()
    {
        StartCoroutine(DislayMessage(messages[0]));
    }
    /// <summary>
    /// Press continue button to skip the displaying animation
    /// </summary>
    public void ContinueMessage()
    {
        currentDisplayingMessage = "";
        if (messageText.maxVisibleCharacters < currentDisplayingMessage.Length)
        {
            messageText.maxVisibleCharacters = currentDisplayingMessage.Length;
            currentNpc.anim.SetBool("talking", false);
        }
        else
        {
            messages.RemoveAt(0);
            if (messages.Count > 0)
                StartDisplayingMessages();
            else
            {
                FindObjectOfType<PlayerMovement>().canMove = true;
                currentNpc.isInteracted = false;
                messageBox.SetActive(false);
            }
        }
    }
    /// <summary>
    /// Accept the quest and sent it to the quest manager
    /// </summary>
    public void AcceptQuest()
    {
        QuestManager.Instance.StartQuest(quest, currentNpc);

        QuestButtons(false);
        ContinueMessage();
    }
    /// <summary>
    /// Deny quest and continue
    /// </summary>
    public void DenyQuest()
    {
        QuestButtons(false);
        ContinueMessage();
    }
    //Set the quest buttons active or not active
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
