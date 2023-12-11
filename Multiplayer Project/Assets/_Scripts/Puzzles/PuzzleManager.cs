using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    [Header("Timer")]
    private bool isTimer;

    public float time = 900f;

    public TMP_Text timerText1;
    public TMP_Text timerText2;

    [Header("Puzzle")]
    public List<Puzzle> puzzles;

    public UnityEvent puzzlesCompleteEvent;

    public UnityEvent completeEvent;
    public UnityEvent failEvent;

    void Start()
    {
        SetTimer(true);
    }

    void Update()
    {
        if (isTimer)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;

                if (time < 0)
                {
                    time = 0;

                    Fail();
                }

                string timeToDisplay = DisplayTime(time);

                timerText1.text = timeToDisplay;
                timerText2.text = timeToDisplay;
            }
        }
    }

    public void SetTimer(bool isActive)
    {
        isTimer = isActive;
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

        puzzlesCompleteEvent.Invoke();
    }

    public void Complete()
    {
        isTimer = false;

        completeEvent.Invoke();
    }

    public void Fail()
    {
        isTimer = false;

        failEvent.Invoke();
    }
}