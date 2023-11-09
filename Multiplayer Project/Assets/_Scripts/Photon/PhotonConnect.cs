using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PhotonConnect : MonoBehaviourPunCallbacks
{
    void Start()
    {
        Debug.Log("Connecting...");
        
        PhotonNetwork.NickName = MasterManager.GameSettings.Nickname;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected.");
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);

        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();

            SetupLocalPlayerProperties();
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"Disconnected.\n{cause.ToString()}");
    }

    private void SetupLocalPlayerProperties()
    {
        Hashtable hash = PhotonNetwork.LocalPlayer.CustomProperties;

        hash.Add("isReady", false);
        hash.Add("isVR", false);

        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }
}