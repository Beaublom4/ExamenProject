using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public float messageSpeed;

    public GameObject messageBox;
    public TMP_Text messageText;
    private string currentDisplayingMessage;
    private bool typingMessage;

    public List<string> messages = new();

    private void Start()
    {
        AddMesssagesAndPlay("Hallo wereld!");
    }
    public void AddMesssagesAndPlay(string _message)
    {
        messages.Add(_message);
        if (!typingMessage)
        {
            messageBox.SetActive(true);
            StartDisplayingMessages();
        }
    }

    IEnumerator DislayMessage(string _message)
    {
        typingMessage = true;
        messageText.maxVisibleCharacters = 0;

        currentDisplayingMessage = _message;
        messageText.text = _message;

        while (messageText.maxVisibleCharacters < _message.Length)
        {
            messageText.maxVisibleCharacters++;
            yield return new WaitForSeconds(messageSpeed);
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
}
