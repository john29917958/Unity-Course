using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour {
	public enum Names { King, Paper, Sisers, Stone }
	public enum Directions { Left, Right, Up, Down, LeftUp, RightUp, LeftDown, RightDown }

	public Names Name;
	public bool IsFrezzed;
	public Grid Grid;
	public List<Directions> AvailableMovementDirections;
}
