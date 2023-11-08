using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static void DestroyChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            MonoBehaviour.Destroy(child.gameObject);
        }
    }
}