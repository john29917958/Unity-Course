using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector2 Direction { get; private set; }
    public Action OnDragStarted;    
    public Action OnDragEnded;

    public RectTransform JoyStickArea;
    public RectTransform Handler;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (OnDragStarted != null) OnDragStarted.Invoke();
        Direction = GetDragDirection(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        SetHandlerPosition(eventData.position);
        Direction = GetDragDirection(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Handler.anchoredPosition = Vector2.zero;
        Direction = Vector2.zero;
        if (OnDragEnded != null) OnDragEnded.Invoke();
    }

    private void SetHandlerPosition(Vector2 pointerPosition)
    {
        Vector2 origin = new Vector2(JoyStickArea.transform.position.x, JoyStickArea.transform.position.y);
        Vector2 diff = pointerPosition - origin;
        float radius = JoyStickArea.rect.width / 2f;

        if (diff.magnitude > radius)
        {
            diff = Vector2.ClampMagnitude(diff, radius);
        }

        Handler.anchoredPosition = diff;
    }

    private Vector2 GetDragDirection(Vector2 pointerPosition)
    {
        Vector2 origin = new Vector2(JoyStickArea.transform.position.x, JoyStickArea.transform.position.y);
        Vector2 diff = pointerPosition - origin;
        Vector2 direction = diff.normalized;
        return direction;
    }
}
