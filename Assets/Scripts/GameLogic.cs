using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public List<Question> questions = new List<Question>();

    Question currentQuestion;
    public Question CurrentQuestion
    {
        get
        {
            return currentQuestion;
        }
    }

    int currentQuestionIndex = 0;
    public int CurrentQuestionIndex
    {
        get
        {
            return currentQuestionIndex + 1;
        }
    }

    string currentHint;
    public string CurrentHint
    {
        get
        {
            return currentHint;
        }
    }

    int currentHintIndex = 0;
    public int CurrentHintIndex
    {
        get
        {
            return currentHintIndex + 1;
        }
    }

    public void InitializeContent()
    {
        currentQuestion = questions[currentQuestionIndex];
        currentHint = currentQuestion.Hints[currentHintIndex];
    }

    public bool IsAnswerCorrect(string answer)
    {
        return currentQuestion.answer == answer;
    }

    public void HandleCorrectAnswer()
    {
        NextQuestion();
    }

    private void NextQuestion()
    {
        ++currentQuestionIndex;
        if (questions.Count > currentQuestionIndex)
        {
            currentQuestion = questions[currentQuestionIndex];

            currentHintIndex = 0;
            currentHint = currentQuestion.Hints[currentHintIndex];
        }
    }

    public void HandleWrongAnswer()
    {
        if(currentHintIndex < 2)
        {
            currentHint = currentQuestion.Hints[++currentHintIndex];
        }
        else
        {
            NextQuestion();
        }
    }
}
