using System;
using UnityEngine;

public class VirtualJoystick : MonoBehaviour
{
    public Vector2 Direction { get; private set; }
    public Action OnDragStarted;    
    public Action OnDragEnded;

    public RectTransform JoyStickArea;
    public RectTransform Handler;

    private int _pressedMouseButton;

    public void StartDrag(int mouseButton)
    {
        if (OnDragStarted != null) OnDragStarted.Invoke();
        _pressedMouseButton = mouseButton;
        Direction = GetDragDirection(Input.mousePosition);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(_pressedMouseButton))
        {
            EndDrag();
            gameObject.SetActive(false);
        }
        else
        {
            OnDrag(Input.mousePosition);
        }
    }

    public void EndDrag()
    {
        Handler.anchoredPosition = Vector2.zero;
        Direction = Vector2.zero;
        if (OnDragEnded != null) OnDragEnded.Invoke();
        gameObject.SetActive(false);
    }

    private void OnDrag(Vector2 mousePosition)
    {
        SetHandlerPosition(mousePosition);
        Direction = GetDragDirection(mousePosition);
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
