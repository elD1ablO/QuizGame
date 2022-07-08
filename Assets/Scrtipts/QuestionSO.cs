using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question = "enter new question text here";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctIndex;
    public string GetQuestion()
    {
        return question;
    }

    public int GetCorrectAnswerIndex()
    {
        return correctIndex;
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }
}
