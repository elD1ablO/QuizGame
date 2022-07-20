using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;    
    int correctAnswerIndex;
    bool answeredEarly;

    [Header ("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    void Awake()
    {
       timer = FindObjectOfType<Timer>();
    }
    void Start()
    {
        DisplayQuestion();
        
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;

        if (timer.loadNextQuestion)
        {
            answeredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if(!answeredEarly && !timer.isAnswering)
        {
            DisplayAnswer(-1);
            SetButtonsState(false);
        }
    }
    void GetNextQuestion()
    {
        SetButtonsState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }
        

    void DisplayQuestion()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
        questionText.text = question.GetQuestion();
        SetButtonsState(true);
    }

    void SetButtonsState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    public void OnAnswerSelected(int index)
    {
        answeredEarly = true;
        DisplayAnswer(index);
        SetButtonsState(false);
        timer.CancelTimer();
    }

    void DisplayAnswer(int index)
    {
        Image buttonImage;

        if (index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswerIndex = question.GetCorrectAnswerIndex();
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            questionText.text = $"Sorry, correct answer was \n {correctAnswer}";

            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    private void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImg = answerButtons[i].GetComponent<Image>();
            buttonImg.sprite = defaultAnswerSprite;
        }
    }

}
