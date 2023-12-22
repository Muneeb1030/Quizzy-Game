using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Setup
{
    public static void InitializeIcons(VisualElement root, List<Question> questions)
    {
        int count = 0;
        foreach (var question in questions)
        {
            VisualElement questionIcon = root.Query<VisualElement>("IconHolder").Children<VisualElement>().AtIndex(count);
            questionIcon.style.backgroundImage = Resources.Load<Texture2D>($"Icons/{question.answer}");
            questionIcon.userData = question;

            count++;
        }
    }

    public static void InitializeDragDrop(VisualElement root, Controller controller)
    {
        root.Query<VisualElement>("IconHolder")
            .Children<VisualElement>()
            .ForEach ((elem) =>
            {
                elem.AddManipulator(new DragManipulator(root, controller));
            });
    }
}
