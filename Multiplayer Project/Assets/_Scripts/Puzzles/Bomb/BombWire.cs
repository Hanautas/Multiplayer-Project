using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BombWire : MonoBehaviour
{
    public bool isComplete = false;
    public bool isCorrect = false;

    public UnityEvent onCut;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Scissor")
        {
            isComplete = true;

            onCut.Invoke();

            gameObject.SetActive(false);
        }
    }
}