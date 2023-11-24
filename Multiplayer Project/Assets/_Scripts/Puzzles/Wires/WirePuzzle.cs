using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePuzzle : Puzzle
{
    public List<PlugController> plugs;

    public override void CheckPuzzle()
    {
        foreach (PlugController plug in plugs)
        {
            if (!plug.isComplete)
            {
                return;
            }
        }

        CompletePuzzle();
    }
}