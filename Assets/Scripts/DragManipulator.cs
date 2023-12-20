using UnityEngine;
using UnityEngine.UIElements;

internal class DragManipulator : PointerManipulator
{
    private VisualElement veroot;
    private VisualElement vedragzone;
    private VisualElement vedropzone;
    private VisualElement veiconholder;

    private bool isdragging;

    private Vector2 startPos;
    private Vector2 startPosGlobal;
    private Vector2 startPosLocal;

    public DragManipulator(VisualElement root)
    {
        veroot = root;
        vedragzone = veroot.Q<VisualElement>("DragZone");
        vedropzone = veroot.Q<VisualElement>("DropZone");
        veiconholder = veroot.Q<VisualElement>("IconHolder");
    }

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<PointerDownEvent>(OnPointerDown);
        target.RegisterCallback<PointerMoveEvent>(OnPointerMove);
        target.RegisterCallback<PointerUpEvent>(OnPointerUp);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<PointerDownEvent>(OnPointerDown);
        target.UnregisterCallback<PointerMoveEvent>(OnPointerMove);
        target.UnregisterCallback<PointerUpEvent>(OnPointerUp);
    }

    private void OnPointerDown(PointerDownEvent evt)
    {
        startPos = evt.localPosition;

        startPosGlobal = target.worldBound.position;
        startPosLocal = target.layout.position;

        vedragzone.style.display = DisplayStyle.Flex;
        vedragzone.Add(target);

        target.style.top = startPosGlobal.y;
        target.style.left = startPosGlobal.x;

        isdragging = true;
        target.CapturePointer(evt.pointerId);
        evt.StopPropagation();
    }

    private void OnPointerMove(PointerMoveEvent evt)
    {
        if (!isdragging || !target.HasPointerCapture(evt.pointerId))
        {
            return;
        }
        Vector2 offset = (Vector2)evt.localPosition - startPos;

        target.style.left = target.layout.x + offset.x;
        target.style.top = target.layout.y + offset.y;
        
    }

    private void OnPointerUp(PointerUpEvent evt)
    {
        if (!isdragging || !target.HasPointerCapture(evt.pointerId))
        {
            return;
        }
        if(target.worldBound.Overlaps(vedropzone.worldBound))
        {
            vedropzone.Add(target);

            target.style.left = vedropzone.contentRect.center.x - target.layout.width / 2;
            target.style.top = vedropzone.contentRect.center.y - target.layout.height / 2;
        }
        else
        {
            veiconholder.Add(target);

            target.style.left = startPosLocal.x - veiconholder.contentRect.position.x;
            target.style.top = startPosLocal.y - veiconholder.contentRect.position.y;
        }

        vedragzone.style.display = DisplayStyle.None;

        isdragging = false;
        target.ReleasePointer(evt.pointerId);
        evt.StopPropagation();
    }
}