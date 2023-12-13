using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DesktopPlayer : PlayerController
{
    public static DesktopPlayer instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (!(bool)PhotonNetwork.LocalPlayer.CustomProperties["isVR"] && !MasterManager.GameSettings.DebugVR)
        {
            playerCamera.enabled = true;
            audioListener.enabled = true;
        }
    }
}