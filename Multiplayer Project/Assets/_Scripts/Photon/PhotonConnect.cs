using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PhotonConnect : MonoBehaviourPunCallbacks
{
    public static PhotonConnect instance;

    void Awake()
    {
        instance = this;
    }

    public void Connect()
    {
        Debug.Log("Connecting...");
        
        PhotonNetwork.LocalPlayer.NickName = MasterManager.GameSettings.NickName;
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

        StartCoroutine(VRManager.instance.StartXRCoroutine());
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

        if (VRManager.instance.debugVR)
        {
            hash["isVR"] = true;
        }

        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }
}