using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    public List<Puzzle> puzzles;

    public UnityEvent completeEvent;

    public void CheckPuzzlesComplete()
    {
        foreach (Puzzle puzzle in puzzles)
        {
            if (!puzzle.isComplete)
            {
                return;
            }
        }

        Complete();
    }

    public void Complete()
    {
        completeEvent.Invoke();
    }
}