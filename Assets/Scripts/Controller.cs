using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameLogic game;
    public GameUI ui;

    private int counter = 0;
    private int Score = 0;

    public int Counter
    {
        get
        {
            return counter;
        }
        set
        {
            if (value == 0)
            {
                HandleWrongAnswer();
                return;
            }
            ui.setTimer(value);
            counter = value;
        }
    }

    public void Start()
    {
        InitializeGame();
    }

    public void InitializeGame()
    {
        game.InitializeContent();
        updateUI();

        Reset();
        StartCoroutine(Timer());
    }

    private void updateUI()
    {
        ui.setHint(game.CurrentHint);
        ui.setHintNum(game.CurrentHintIndex);
        ui.setQuestionNum(game.CurrentQuestionIndex);
    }
    public void HandleCorrectANswer()
    {
        game.HandleCorrectAnswer();
        updateUI();
        NextButtonStatus();
        Score +=10;
        ui.setScore(Score);
        Reset();
    }
    public void HandleWrongAnswer()
    {
        game.HandleWrongAnswer();
        updateUI();
        NextButtonStatus();
        Score -=2;
        ui.setScore(Score);
        Reset();
    }

    public void CheckAnswer(string answer)
    {
        bool isCorrect = game.IsAnswerCorrect(answer);
        if (isCorrect)
        {
            HandleCorrectANswer();
        }
        else
        {
            HandleWrongAnswer();
        }
        ui.setFeedback(isCorrect);
    }

    public List<Question> GetQuestions()
    {
        return game.questions;
    }
    public void NextButtonStatus()
    {
        bool status = game.questions.Count == game.CurrentQuestionIndex && game.CurrentHintIndex == 3;
        ui.ButtonStatus(!status);
    }
    private void Reset()
    {
        Counter = 10;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        Counter--;
        StartCoroutine(Timer());
    }
}
