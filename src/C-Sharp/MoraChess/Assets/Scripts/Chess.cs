using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chess : MonoBehaviour {
	public enum Names { King, Paper, Sisers, Stone }
	public enum Directions { Left, Right, Up, Down, LeftUp, RightUp, LeftDown, RightDown }

	public GameManager GameManager;

	public Names Name;
	public Players Owner;

	public bool IsFrezzed;

	public Text NameDescription;
	public Grid Grid;
	public List<Directions> AvailableMovementDirections;	

	public void OnChessClicked()
	{

	}

	protected void Start()
	{
		NameDescription.text = Name.ToString();
	}
}
