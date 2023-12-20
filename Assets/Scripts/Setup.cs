using UnityEngine;
using UnityEngine.UIElements;

public class Setup
{
    public static void Initialize(VisualElement root)
    {
        InitializeDragDrop(root);
        InitializeIcons(root);
    }

    private static void InitializeIcons(VisualElement root)
    {
        
    }

    private static void InitializeDragDrop(VisualElement root)
    {
        root.Query<VisualElement>("IconHolder")
            .Children<VisualElement>()
            .ForEach ((elem) =>
            {
                elem.AddManipulator(new DragManipulator(root));
            });
    }
}
