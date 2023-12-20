using System;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameLogic game;
    public GameUI ui;

    public void Start()
    {
        InitializeGame();
    }

    public void InitializeGame()
    {
        game.InitializeContent();
        updateUI();
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
    }
    public void HandleWrongAnswer()
    {
        game.HandleWrongAnswer();
        updateUI();
    }
}
