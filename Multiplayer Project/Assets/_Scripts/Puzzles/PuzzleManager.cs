using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public List<Puzzle> puzzles;

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

    }
}