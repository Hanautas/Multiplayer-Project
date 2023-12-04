using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BombPuzzle : Puzzle
{
    public UnityEvent failEvent;

    public List<BombWire> bombWires;

    public override void CheckPuzzle()
    {
        foreach (BombWire wire in bombWires)
        {
            if (wire.isComplete && wire.isCorrect)
            {
                CompletePuzzle();
            }
            else if (wire.isComplete && !wire.isCorrect)
            {
                failEvent.Invoke(); 
            }
        }
    }
}