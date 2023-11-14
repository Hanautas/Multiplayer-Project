using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviourPunCallbacks
{
    private bool showOnce = false;

    public GameObject connectMenu;
    public GameObject mainMenu;
    public GameObject lobbyMenu;

    public TMP_Text versionText;
    public TMP_Text nickNameText;

    public TMP_InputField nickNameInputField;

    void Start()
    {
        versionText.text = $"v{MasterManager.GameSettings.GameVersion}";

        nickNameInputField.text = PhotonNetwork.LocalPlayer.NickName;
    }

    public void SetLocalPlayerNickName()
    {
        PhotonNetwork.LocalPlayer.NickName = nickNameText.text;
    }
    
    public override void OnConnectedToMaster()
    {
        if (!showOnce)
        {
            showOnce = true;

            connectMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
    }

    public void Play()
    {
        mainMenu.SetActive(false);
        lobbyMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game.");

        Application.Quit();
    }
}