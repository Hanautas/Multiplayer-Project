using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Chat;
using ExitGames.Client.Photon;
using TMPro;

public class ChatManager : MonoBehaviour, IChatClientListener
{
    public bool isConnected;

    private string currentChat;

    private ChatClient chatClient;

    [Header("UI")]
    public TMP_Text chatText;
    public TMP_InputField chatInputField;

    void Start()
    {
        ConnectToChat();
    }

    void Update()
    {
        if (isConnected)
        {
            chatClient.Service();
        }
    }

    public void ConnectToChat()
    {
        chatClient = new ChatClient(this);
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues(PhotonNetwork.LocalPlayer.NickName));
    }

    public void SubmitPublicChat()
    {
        chatClient.PublishMessage("RegionChannel", currentChat);

        chatInputField.text = "";
        currentChat = "";
    }

    public void DebugReturn(DebugLevel level, string message)
    {
        
    }

    public void OnDisconnected()
    {
        isConnected = false;
    }

    public void OnConnected()
    {
        isConnected = true;

        chatClient.Subscribe(new string[] { "RegionChannel" });
    }

    public void OnChatStateChange(ChatState state)
    {
        
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        for (int i = 0; i < senders.Length; i++)
        {
            chatText.text += $"\n{senders[i]}: {messages[i]}";
        }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        
    }

    public void OnUnsubscribed(string[] channels)
    {
        
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        
    }

    public void OnUserSubscribed(string channel, string user)
    {
        
    }

    public void OnUserUnsubscribed(string channel, string user)
    {

    }
}