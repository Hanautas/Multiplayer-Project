using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipsPuzzle : Puzzle
{
    public List<Computer> computers;

    public override void CheckPuzzle()
    {
        foreach (Computer computer in computers)
        {
            if (!computer.isComplete)
            {
                return;
            }
        }

        CompletePuzzle();
    }
}