using UnityEngine;
using UnityEngine.UIElements;

public class GameLogic : MonoBehaviour
{
    private VisualElement veroot;
    private VisualElement vetesticon;

    private void OnEnable()
    {
        veroot = GetComponent<UIDocument>().rootVisualElement;
        vetesticon = veroot.Q<VisualElement>("testIcon");

        vetesticon.AddManipulator(new DragManipulator(veroot));


    }
}
