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

    public static object GetLocalPlayerProperty(string propertyName)
    {
        return PhotonNetwork.LocalPlayer.CustomProperties[propertyName];
    }

    public static void SetLocalPlayerPropertyBool(string propertyName, bool value)
    {
        Hashtable hash = PhotonNetwork.LocalPlayer.CustomProperties;

        hash[propertyName] = value;

        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }
}