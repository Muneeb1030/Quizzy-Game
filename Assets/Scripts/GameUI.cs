using UnityEngine;
using UnityEngine.UIElements;

public class GameUI : MonoBehaviour
{
    public Controller controller;

    private VisualElement veroot;

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

        lbQuestionNum = veroot.Q<Label>("Question");
        lbFeedback = veroot.Q<Label>("Feed");
        lbScore = veroot.Q<Label>("Score");
        lbTime = veroot.Q<Label>("Time");
        lbHintNum = veroot.Q<Label>("hintnum");
        lbHint = veroot.Q<Label>("hint");

        btnNextHint = veroot.Q<Button>("nexthint");
        btnNextHint.RegisterCallback<ClickEvent>((evt) =>
        {
            controller.HandleWrongAnswer();
        });

        Setup.Initialize(veroot);
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
}
