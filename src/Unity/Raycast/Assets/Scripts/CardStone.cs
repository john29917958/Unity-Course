using UnityEngine;

public class CardStone : MonoBehaviour
{
    [SerializeField]
    private Canvas _canvas;

    public void Attach(Card card)
    {
        card.gameObject.transform.SetParent(_canvas.transform);
        card.transform.position = _canvas.transform.position;
        card.CardContent.transform.position = card.transform.position;
    }
}
