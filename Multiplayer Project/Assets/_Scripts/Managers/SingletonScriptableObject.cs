using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
    private static T instance = null;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                T[] results = Resources.FindObjectsOfTypeAll<T>();

                if (results.Length == 0)
                {
                    Debug.Log("1");
                    return null;
                }

                if (results.Length > 1)
                {
                    Debug.Log("2");
                    return null;
                }

                instance = results[0];
            }

            return instance;
        }
    }
}