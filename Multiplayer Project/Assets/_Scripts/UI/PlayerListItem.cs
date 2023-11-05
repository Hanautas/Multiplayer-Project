using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;

public class PlayerListItem : MonoBehaviour
{
    public TMP_Text text;

    public Player player;

    public void SetPlayerInfo(Player info)
    {
        player = info;

        text.text = $"{player.NickName}";
    }
}