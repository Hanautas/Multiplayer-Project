using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using TMPro;

public class PlayerListItem : MonoBehaviourPunCallbacks
{
    public TMP_Text nameText;
    public TMP_Text readyText;

    public Player player;

    public void SetPlayerInfo(Player info)
    {
        Hashtable hash = info.CustomProperties;

        if (!hash.ContainsKey("isReady"))
        {
            hash.Add("isReady", false);
        }

        info.SetCustomProperties(hash);

        player = info;

        nameText.text = $"{player.NickName}";

        SetPlayerIsReady();
    }

    public bool GetPlayerIsReady()
    {
        return (bool)player.CustomProperties["isReady"];
    }

    private void SetPlayerIsReady()
    {
        if (GetPlayerIsReady())
        {
            readyText.color = Color.green;
            readyText.text = "Ready";
        }
        else
        {
            readyText.color = Color.red;
            readyText.text = "Not Ready";
        }
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        SetPlayerIsReady();
    }
}