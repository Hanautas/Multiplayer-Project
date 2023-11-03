using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public TMP_Text roomName;
    public Transform content;

    public Room room;

    private List<Room> rooms = new List<Room>();

    public void CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }

        RoomOptions options = new RoomOptions();
        
        options.MaxPlayers = 2;

        PhotonNetwork.JoinOrCreateRoom(roomName.text, options,  TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created room successfully.");
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
                int index = rooms.FindIndex(x => x.RoomInfo.Name == roomInfo.Name);

                if (index != -1)
                {
                    Destroy(rooms[index].gameObject);
                    
                    rooms.RemoveAt(index);
                }
            }
            else
            {
                Room newRoom = Instantiate(room, content);

                newRoom.SetRoomInfo(roomInfo);

                rooms.Add(newRoom);
            }
        }
    }
}