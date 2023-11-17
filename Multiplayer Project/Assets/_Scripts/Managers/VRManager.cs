using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;
 
public class VRManager : MonoBehaviour
{
    public static VRManager instance;

    public bool debugVR = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(StartXRCoroutine());
    }

    public IEnumerator StartXRCoroutine()
    {
        var enableVRArg = "--enable-vr";
 
        Debug.Log("Looking if VR should enable");

        if (debugVR || Utility.GetArg(enableVRArg))
        {
            Utility.SetLocalPlayerPropertyBool("isVR", true);

            Debug.Log("Initializing XR...");

            yield return XRGeneralSettings.Instance.Manager.InitializeLoader();
 
            if (XRGeneralSettings.Instance.Manager.activeLoader == null)
            {
                Debug.LogError("Initializing XR Failed. Check Editor or Player log for details.");
            }
            else
            {
                Debug.Log("Starting XR...");

                XRGeneralSettings.Instance.Manager.StartSubsystems();
            }
        }
        else
        {
            Debug.Log("Did not find VR arg, starting in 2D");
        }

        GameManager.instance.LoadStartScene();
    }
}