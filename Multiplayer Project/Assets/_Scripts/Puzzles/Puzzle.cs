using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Puzzle : MonoBehaviour
{
    public bool isComplete;

    public UnityEvent completeEvent;

    public virtual void CheckPuzzle()
    {
        
    }

    public virtual void CompletePuzzle()
    {
        isComplete = true;

        completeEvent.Invoke();
    }
}