using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour {
	public Text Text;
	public Button Button;
	public NineGrid NineGrid;

	public int Row;
	public int Col;

	public void OnClicked()
	{
		Text.text = NineGrid.PlayerIcon;
		Button.interactable = false;

		NineGrid.SetGridValue(Row, Col);		
	}
}
