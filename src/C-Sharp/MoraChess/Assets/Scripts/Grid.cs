using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
	public Controller GameManager;

	public int Row;
	public int Column;
	public List<Chess> Chesses = new List<Chess>();

	public void OnGridClicked()
	{
		GameManager.OnClick(this);
	}
}
