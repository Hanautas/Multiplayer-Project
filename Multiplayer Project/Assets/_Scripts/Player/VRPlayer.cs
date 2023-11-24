using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class VRPlayer : MonoBehaviour
{
    public static VRPlayer instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SetHeight(MasterManager.GameSettings.VRPlayerHeight);

        var xrInput = XRGeneralSettings.Instance.Manager.activeLoader.GetLoadedSubsystem<XRInputSubsystem>();

        xrInput.TrySetTrackingOriginMode(TrackingOriginModeFlags.Device);
        xrInput.TryRecenter();
    }

    public void SetHeight(float height)
    {
        transform.localScale = new Vector3(height, height, height);
    }
}