using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatMessage : MonoBehaviour
{
    public TMP_Text messageText;

    public void Setup(string sender, string message)
    {
        messageText.text = $"{sender}: {message}";
    }
}