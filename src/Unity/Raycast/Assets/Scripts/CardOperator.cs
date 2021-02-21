using UnityEngine;

public class CardOperator : MonoBehaviour
{
	[SerializeField]
	private Canvas _cardCanvas;

	[SerializeField]
	private LayerMask _cardLayer;

	[SerializeField]
	private LayerMask _cardStoneLayer;

	private Card _selectedCard;
	private Vector3 _cardOriginPosition;

	// Update is called once per frame
	void Update ()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Input.GetMouseButtonDown(0))
        {	
			RaycastHit hitInfo;
			if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, _cardLayer))
            {
				_cardOriginPosition = hitInfo.transform.position;
				_selectedCard = hitInfo.transform.GetComponent<Card>();
			}
        }
		else if (Input.GetMouseButton(0) && _selectedCard != null)
        {			
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cardCanvas.planeDistance));
			_selectedCard.CardContent.transform.position = new Vector3(_cardOriginPosition.x, mousePosition.y, mousePosition.z);
		}
		else if (Input.GetMouseButtonUp(0) && _selectedCard != null)
        {
			RaycastHit hitInfo;

			if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, _cardStoneLayer))
			{
				CardStone cardStone = hitInfo.transform.GetComponent<CardStone>();
				cardStone.Attach(_selectedCard);
            }
			else
            {
				_selectedCard.CardContent.transform.position = _selectedCard.transform.position;				
			}

			_selectedCard = null;
			_cardOriginPosition = Vector3.zero;
		}
	}
}
