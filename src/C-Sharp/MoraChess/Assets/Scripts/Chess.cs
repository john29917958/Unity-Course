using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chess : MonoBehaviour {
	public enum Names { King, Paper, Sisers, Stone }

	public Controller GameManager;
	public Button ChessButton;

	public Names Name;
	public Players Owner;

	public void SetOwner(Players owner)
	{
		Owner = owner;

		if (owner == Players.Player1)
		{
			Color color;
			ColorBlock colors = ChessButton.colors;

			ColorUtility.TryParseHtmlString("#0277BDFF", out color);
			colors.normalColor = color;

			ColorUtility.TryParseHtmlString("#0288D1FF", out color);
			colors.highlightedColor = color;

			ColorUtility.TryParseHtmlString("#01579BFF", out color);
			colors.pressedColor = color;

			ChessButton.colors = colors;
		}
		else
		{
			Color color;
			ColorBlock colors = ChessButton.colors;

			ColorUtility.TryParseHtmlString("#C62828FF", out color);
			colors.normalColor = color;

			ColorUtility.TryParseHtmlString("#D32F2FFF", out color);
			colors.highlightedColor = color;

			ColorUtility.TryParseHtmlString("#B71C1CFF", out color);
			colors.pressedColor = color;

			ChessButton.colors = colors;
		}
	}

	public bool IsFrezzed;
	public bool IsDead;

	public Text NameDescription;
	public Grid Grid;
	public List<Directions> AvailableMovementDirections;

	private Players _owner;

	public void OnChessClicked()
	{
		GameManager.OnClick(this);
	}

	protected void Start()
	{
		NameDescription.text = Name.ToString();
	}
}
