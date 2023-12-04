using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatEmote : MonoBehaviour
{
    public TMP_Text nameText;
    public Image image;

    public void Setup(string sender, Sprite sprite)
    {
        nameText.text = $"{sender}: ";
        image.sprite = sprite;
    }
}