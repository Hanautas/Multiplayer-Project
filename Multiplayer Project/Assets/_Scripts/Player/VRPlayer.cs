using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;
using Photon.Pun;

public class VRPlayer : PlayerController
{
    public static VRPlayer instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if ((bool)PhotonNetwork.LocalPlayer.CustomProperties["isVR"] || MasterManager.GameSettings.DebugVR)
        {
            playerCamera.enabled = true;
            audioListener.enabled = true;
        }

        if ((bool)PhotonNetwork.LocalPlayer.CustomProperties["isVR"] && !MasterManager.GameSettings.DebugVR)
        {
            //Recenter();

            SetHeight(MasterManager.GameSettings.VRPlayerHeight);
        }
    }

    public void Recenter()
    {
        var xrInput = XRGeneralSettings.Instance.Manager.activeLoader.GetLoadedSubsystem<XRInputSubsystem>();

        xrInput.TrySetTrackingOriginMode(TrackingOriginModeFlags.Device);
        xrInput.TryRecenter();
    }

    public void SetHeight(float height)
    {
        transform.localScale = new Vector3(height, height, height);
    }
}