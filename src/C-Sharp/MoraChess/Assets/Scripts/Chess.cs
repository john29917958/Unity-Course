using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chess : MonoBehaviour {
	public enum Names { King, Paper, Sisers, Stone }	

	public Controller GameManager;

	public Names Name;
	public Players Owner;

	public bool IsFrezzed;

	public Text NameDescription;
	public Grid Grid;
	public List<Directions> AvailableMovementDirections;	

	public void OnChessClicked()
	{
		GameManager.OnClick(this);
	}

	protected void Start()
	{
		NameDescription.text = Name.ToString();
	}
}
