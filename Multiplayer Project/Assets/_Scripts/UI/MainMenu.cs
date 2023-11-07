using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_Text versionText;

    void Start()
    {
        versionText.text = $"v{MasterManager.GameSettings.GameVersion}";
    }

    public void QuitGame()
    {
        Debug.Log("Quit game.");

        Application.Quit();
    }
}