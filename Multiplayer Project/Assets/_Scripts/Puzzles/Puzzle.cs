using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Puzzle : MonoBehaviour
{
    public bool isComplete;

    public UnityEvent onCompleteEvent;

    public virtual void CheckPuzzle()
    {
        
    }

    public virtual void CompletePuzzle()
    {
        isComplete = true;

        onCompleteEvent.Invoke();
    }
}