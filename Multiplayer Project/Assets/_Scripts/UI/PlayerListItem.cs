using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using TMPro;

public class PlayerListItem : MonoBehaviour
{
    public TMP_Text text;

    public Player player;

    public void SetPlayerInfo(Player info)
    {
        Hashtable hash = new Hashtable();
        hash.Add("isReady", false);

        info.SetCustomProperties(hash);

        player = info;
Debug.Log(player.CustomProperties["isReady"]);
        text.text = $"{player.NickName}\n{player.CustomProperties["isReady"]}";
    }
}