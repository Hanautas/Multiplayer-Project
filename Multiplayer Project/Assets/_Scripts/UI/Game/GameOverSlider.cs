using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverSlider : MonoBehaviour
{
    private bool isActive;

    public int time;

    public Slider slider;

    void Update()
    {
        if (isActive)
        {
            if (slider.value < time)
            {
                slider.value += Time.deltaTime;
            }
            else if (slider.value >= time)
            {
                GameManager.instance.LoadScene("Main Menu");
            }
        }
    }

    public void SetActive()
    {
        isActive = true;
    }
}