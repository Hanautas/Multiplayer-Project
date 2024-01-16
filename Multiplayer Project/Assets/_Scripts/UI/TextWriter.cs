using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWriter : MonoBehaviour
{
    public float textDelay = 0.025f;

    [TextArea(5, 10)]
    public string text;

    public TMP_Text textField;

    IEnumerator Start()
    {
        StartCoroutine(TypeText());

        yield return new WaitForSeconds(15f);

        GameManager.instance.LoadScene("Game");
    }

    private IEnumerator TypeText()
    {
        textField.text = "";
        
        for (int i = 0; i < text.Length; i++)
        {
            textField.text += text[i];

            yield return new WaitForSeconds(textDelay);
        }
    }
}