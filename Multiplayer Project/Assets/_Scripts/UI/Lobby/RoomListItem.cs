using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class RoomListItem : MonoBehaviour
{
    public TMP_Text text;

    public RoomInfo roomInfo;

    public void SetRoomInfo(RoomInfo info)
    {
        roomInfo = info;

        text.text = $"{roomInfo.Name}\n{roomInfo.PlayerCount}/{roomInfo.MaxPlayers} Players";
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomInfo.Name);
    }
}