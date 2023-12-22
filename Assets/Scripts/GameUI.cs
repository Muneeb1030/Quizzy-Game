using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class GameUI : MonoBehaviour
{
    public Controller controller;

    private VisualElement veroot;
    public VisualElement dropzone;

    private Label lbQuestionNum;
    private Label lbFeedback;
    private Label lbScore;
    private Label lbTime;
    private Label lbHintNum;
    private Label lbHint;

    private Button btnNextHint;

    private void OnEnable()
    {
        veroot = GetComponent<UIDocument>().rootVisualElement;
        dropzone = veroot.Q<VisualElement>("DropZone");

        lbQuestionNum = veroot.Q<Label>("Question");
        lbFeedback = veroot.Q<Label>("Feed");
        lbScore = veroot.Q<Label>("Score");
        lbTime = veroot.Q<Label>("Time");
        lbHintNum = veroot.Q<Label>("hintnum");
        lbHint = veroot.Q<Label>("hint");

        lbScore.text = "Score: 0";

        btnNextHint = veroot.Q<Button>("nexthint");
        btnNextHint.RegisterCallback<ClickEvent>((evt) =>
        {
            controller.HandleWrongAnswer();
        });

        Setup.InitializeDragDrop(veroot, controller);
        Setup.InitializeIcons(veroot, controller.GetQuestions());
        
    }

    public void setHint(string arghint)
    {
        lbHint.text = $"{arghint}";
    }

    public void setQuestionNum(int argQuestionNum)
    {
        lbQuestionNum.text = $"Question No: 0{argQuestionNum}";
    }

    public void setHintNum(int argQuestionNum)
    {
        lbHintNum.text = $"Hint: 0{argQuestionNum}";
    }

    public void setFeedback(bool correct)
    {
        lbFeedback.style.visibility = Visibility.Visible;
        lbFeedback.text = correct ? "Your Answer is Correct!" : "Your Answer is Wrong!";
        lbFeedback.style.color = correct ? Color.green : Color.red;
        StartCoroutine(HideFeedback());
    }

    private IEnumerator HideFeedback()
    {
        yield return new WaitForSeconds(3);
        lbFeedback.style.visibility = Visibility.Hidden;
        if(dropzone.childCount > 0)
        {
            dropzone.RemoveAt(0);
        }
    }

    public void setTimer(int time)
    {
        lbTime.text = $"Time Remaining: {time} sec";
    }

    public void setScore(int score)
    {
        lbScore.text = $"Score: {score}";
    }

    internal void ButtonStatus(bool status)
    {
        btnNextHint.style.visibility = status ? Visibility.Visible : Visibility.Hidden;
    }
}
