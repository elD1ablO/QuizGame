using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToComplete = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 7f;

    public bool loadNextQuestion;
    public bool isAnswering = false;
    public float fillFraction;

    float timerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        //isAnswering = true;
        timerValue -= Time.deltaTime;

        if (isAnswering)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToComplete;
            }            
            else
            {
                isAnswering = false;
                timerValue = timeToShowCorrectAnswer;                
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                isAnswering = true;
                timerValue = timeToComplete;
                loadNextQuestion = true;
            }
        }
        
    }
}
