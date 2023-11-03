using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;

public class Room : MonoBehaviour
{
    public TMP_Text text;

    public RoomInfo info;

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        info = roomInfo;

        text.text = $"{roomInfo.Name}\n{roomInfo.MaxPlayers}";
    }
}