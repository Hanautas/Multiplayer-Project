using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Manager/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField]
    private string gameVersion = "0.0.0";
    public string GameVersion { get { return gameVersion; } }

    [SerializeField]
    private string nickName = "Player";
    public string NickName
    {
        get
        {
            int value = Random.Range(0, 9999);
            return $"{nickName}_{value.ToString()}";
        }
    }
/*
    [SerializeField]
    private bool isVR = false;
    public bool IsVR { get { return isVR; } set { isVR = value; } }
*/
    [SerializeField]
    private float vRPlayerHeight = 1f;
    public float VRPlayerHeight { get { return vRPlayerHeight; } set { vRPlayerHeight = value; } }
}