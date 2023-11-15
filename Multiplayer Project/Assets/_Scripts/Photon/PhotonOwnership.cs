using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonOwnership : MonoBehaviourPunCallbacks
{
    public bool isVR;
    
    void Start()
    {
        if ((isVR && (bool)PhotonNetwork.LocalPlayer.CustomProperties["isVR"]) || (!isVR && !(bool)PhotonNetwork.LocalPlayer.CustomProperties["isVR"]))
        {
            base.photonView.RequestOwnership();
        }
    }
}