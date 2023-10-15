using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonConnect : MonoBehaviourPunCallbacks
{
    public string gameVersion = "0.0.1";

    void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();

        Debug.Log("Connecting");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected");
    }
}