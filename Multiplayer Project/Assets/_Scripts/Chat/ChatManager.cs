using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Chat;
using ExitGames.Client.Photon;
using TMPro;

public class ChatManager : MonoBehaviour, IChatClientListener
{
    public bool isConnected;

    private string currentChat;

    private ChatClient chatClient;

    [Header("Desktop UI")]
    public Transform content;
    public TMP_InputField chatInputField;

    [Header("VR UI")]
    public Transform contentVR;

    private Dictionary<string, Sprite> emotes = new Dictionary<string, Sprite>();

    void Start()
    {
        ConnectToChat();

        foreach (Sprite sprite in Resources.LoadAll<Sprite>("UI/Emotes"))
        {
            emotes.Add(sprite.name, sprite);
        }
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
        isConnected = true;

        chatClient = new ChatClient(this);
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat,
            PhotonNetwork.AppVersion,
            new AuthenticationValues(PhotonNetwork.LocalPlayer.NickName));
    }

    public void ChatInputOnValueChanged(string value)
    {
        currentChat = value;
    }

    public void PublishChatMessage()
    {
        if (!string.IsNullOrEmpty(currentChat))
        {
            chatClient.PublishMessage("RegionChannel", currentChat);

            chatInputField.text = "";
            currentChat = "";
        }
    }

    private void CreateChatMessage(string sender, string message)
    {
        ChatMessage messageObject = Instantiate(Resources.Load<ChatMessage>("UI/Chat/ChatMessage"), content);
        messageObject.Setup(sender, message);

        ChatMessage messageObjectVR = Instantiate(Resources.Load<ChatMessage>("UI/Chat/ChatMessage"), contentVR);
        messageObjectVR.Setup(sender, message);
    }

    public void PublishChatEmote(string emoteName)
    {
        chatClient.PublishMessage("RegionChannel", emoteName);
    }

    private void CreateChatEmote(string emoteName)
    {
        ChatEmote emoteObject = Instantiate(Resources.Load<ChatEmote>("UI/Chat/ChatEmote"), content);
        emoteObject.Setup("VR Player", emotes[emoteName]);

        ChatEmote emoteObjectVR = Instantiate(Resources.Load<ChatEmote>("UI/Chat/ChatEmote"), contentVR);
        emoteObjectVR.Setup("VR Player", emotes[emoteName]);
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
            string message = messages[i].ToString();

            if (emotes.ContainsKey(message))
            {
                CreateChatEmote(message);
            }
            else
            {
                CreateChatMessage(senders[i], message);
            }
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