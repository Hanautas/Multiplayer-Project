using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    [Header("Timer")]
    public bool isTimer = true;

    //public float time = 900f;
    public float timeRemaining = 900f;

    public TMP_Text timerText1;
    public TMP_Text timerText2;

    [Header("Puzzle")]
    public List<Puzzle> puzzles;

    public UnityEvent completeEvent;

    void Update()
    {
        if (isTimer)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;

                if (timeRemaining < 0)
                {
                    isTimer = false;

                    timeRemaining = 0;
                }

                string timeToDisplay = DisplayTime(timeRemaining);

                timerText1.text = timeToDisplay;
                timerText2.text = timeToDisplay;
            }
        }
    }

    private string DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        return string.Format("{0:00}:{1:00}",minutes, seconds);
    }

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