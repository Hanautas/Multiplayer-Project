using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameDoneScreen : MonoBehaviour
{
    public bool isActive;
    public Slider slider;

    void Update()
    {
        if(isActive){
            if(slider.value < 7){
            slider.value += Time.deltaTime;
            }
            else if(slider.value >=7){
                GameManager.instance.LoadScene("Main Menu");
            }
        }
    }
    public void SetActive(){
        isActive = true;
    }
}
