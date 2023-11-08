using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [Header("Menu")]
    public GameObject lobbyMenu;
    public GameObject currentRoomMenu;

    [Header("Room")]
    public TMP_Text roomNameInputField;
    public Transform roomContent;

    private List<RoomListItem> rooms = new List<RoomListItem>();

    [Header("Player")]
    public Transform playerContent;

    private List<PlayerListItem> players = new List<PlayerListItem>();

    public void CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }

        RoomOptions options = new RoomOptions();
        
        options.MaxPlayers = 2;

        PhotonNetwork.JoinOrCreateRoom(roomNameInputField.text, options, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created room successfully.");

        lobbyMenu.gameObject.SetActive(false);
        currentRoomMenu.gameObject.SetActive(true);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log($"Room creation failed.\n{message}");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo roomInfo in roomList)
        {
            if (roomInfo.RemovedFromList)
            {
                int index = rooms.FindIndex(x => x.roomInfo.Name == roomInfo.Name);

                if (index != -1)
                {
                    Destroy(rooms[index].gameObject);
                    
                    rooms.RemoveAt(index);
                }
            }
            else
            {
                RoomListItem roomListItem = Instantiate(Resources.Load<RoomListItem>("UI/RoomListItem"), roomContent);

                roomListItem.SetRoomInfo(roomInfo);

                rooms.Add(roomListItem);
            }
        }
    }

    public override void OnJoinedRoom()
    {
        GetCurrentRoomPlayers();

        lobbyMenu.gameObject.SetActive(false);
        currentRoomMenu.gameObject.SetActive(true);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListItem(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = players.FindIndex(x => x.player == otherPlayer);

        if (index != -1)
        {
            Destroy(players[index].gameObject);
            
            players.RemoveAt(index);
        }
    }

    private void GetCurrentRoomPlayers()
    {
        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListItem(playerInfo.Value);
        }
    }

    private void AddPlayerListItem(Player newPlayer)
    {
        PlayerListItem playerListItem = Instantiate(Resources.Load<PlayerListItem>("UI/PlayerListItem"), playerContent);

        playerListItem.SetPlayerInfo(newPlayer);

        players.Add(playerListItem);
    }
}