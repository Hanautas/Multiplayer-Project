using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public static class Utility
{
    public static void DestroyChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            MonoBehaviour.Destroy(child.gameObject);
        }
    }

    public static bool GetLocalPlayerProperty(string propertyName)
    {
        return (bool)PhotonNetwork.LocalPlayer.CustomProperties[propertyName];
    }

    public static void SetLocalPlayerPropertyBool(string propertyName, bool value)
    {
        Hashtable hash = PhotonNetwork.LocalPlayer.CustomProperties;

        hash[propertyName] = value;

        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }

    public static bool GetArg(string name)
    {
        var args = System.Environment.GetCommandLineArgs();

        for (int i = 0; i < args.Length; i++)
        {
            Debug.Log($"Arg {i}: {args[i]}");

            if (args[i] == name)
            {
                return true;
            }
        }

        return false;
    }
}