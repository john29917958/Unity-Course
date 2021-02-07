using UnityEngine;
using UnityEngine.EventSystems;

public class EventSprite : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerEnter()
    {
        Debug.Log("Mouse entered!");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("I'm clicked!");
    }    
}
