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
    private bool nextMessage;

    //Set instance
    private void Awake()
    {
        Instance = this;
    }
    /// <summary>
    /// Add a message to the list of messages, and play if its not yet playing
    /// </summary>
    /// <param name="_message"></param>
    public void AddMessageAndPlay(Message _message, NPC _npc, bool _nextMessage)
    {
        _message.npc = _npc;
        nextMessage = _nextMessage;
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
    public void AddMessageAndPlay(Message[] _messages, NPC _npc, bool _nextMessage)
    {
        foreach (Message m in _messages)
        {
            AddMessageAndPlay(m, _npc, _nextMessage);
        }
    }

    //Routine of messages playing
    IEnumerator DislayMessage(Message _message)
    {
        FindObjectOfType<PlayerMovement>().canMove = _message.continueMovement;

        typingMessage = true;
        messageText.maxVisibleCharacters = 0;
        currentNpc = _message.npc;
        currentNpc.anim.SetBool("talking", true);

        currentDisplayingMessage = _message.message;
        messageText.text = _message.message;

        if (_message.isQuest)
            nextMessage = false;

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
        //Check if message fully visable and finish showing it
        if (messageText.maxVisibleCharacters < currentDisplayingMessage.Length)
        {
            messageText.maxVisibleCharacters = currentDisplayingMessage.Length;
        }
        else
        {
            messages.RemoveAt(0);
            //Display next message
            if (messages.Count > 0)
                StartDisplayingMessages();
            //Disable the conversation settings
            else
            {
                FindObjectOfType<PlayerMovement>().canMove = true;
                currentNpc.isInteracted = false;
                messageBox.SetActive(false);
                currentNpc.anim.SetBool("talking", false);
                if(nextMessage)
                    currentNpc.currentMessages++;
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
    public string message;
    [Space]
    public bool isQuest;
    public Quest quest;
    [Space]
    public bool continueMovement;
    [Space]
    [HideInInspector] public NPC npc;
}
