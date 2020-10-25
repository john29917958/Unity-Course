using System;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	public enum RoundPhases { SetActionChess, Action }

	public Players RoundOwner = Players.Player1;
	public RoundPhases Phase;
	public Chess ActionChess;

	public void OnClick(Grid grid)
	{
		if (Phase == RoundPhases.Action)
		{
			if (!IsMoveDirectionValid(ActionChess.Grid, grid, ActionChess.AvailableMovementDirections))
			{
				Debug.Log("Invalid direction");
				return;
			}

			ActionChess.Grid.Chesses.Remove(ActionChess);
			ActionChess.Grid = grid;
			grid.Chesses.Add(ActionChess);
			ActionChess.gameObject.transform.position = grid.gameObject.transform.position;

			SwitchRound();
		}
	}

	public void OnClick(Chess chess)
	{
		if (chess.Owner == RoundOwner)
		{
			Debug.Log("Set action chess");
			ActionChess = chess;
			Phase = RoundPhases.Action;
			return;
		}

		if (Phase == RoundPhases.Action && chess.Owner != RoundOwner)
		{
			if (IsMoveDirectionValid(ActionChess.Grid, chess.Grid, ActionChess.AvailableMovementDirections))
			{
				Debug.Log("Attack");
				//TODO: Checks and attacks enemy.
				SwitchRound();
			}
			else
			{
				Debug.Log("Invalid attack direction");
			}
		}
	}

	public void SwitchRound()
	{

	}

	// Use this for initialization
	void Start () {
		
	}
	
	private bool IsMoveDirectionValid(Grid chessGrid, Grid target, List<Directions> validDirections)
	{
		foreach (Directions direction in validDirections)
		{
			switch (direction)
			{
				case Directions.Up:
					if (target.Row + 1 == chessGrid.Row && target.Column == chessGrid.Column) return true;
					break;
				case Directions.Down:
					if (target.Row - 1 == chessGrid.Row && target.Column == chessGrid.Column) return true;
					break;
				case Directions.Left:
					if (target.Row == chessGrid.Row && target.Column + 1 == chessGrid.Column) return true;
					break;
				case Directions.Right:
					if (target.Row == chessGrid.Row && target.Column - 1 == chessGrid.Column) return true;
					break;
				case Directions.LeftUp:
					if (target.Row + 1 == chessGrid.Row && target.Column + 1 == chessGrid.Column) return true;
					break;
				case Directions.RightUp:
					if (target.Row + 1 == chessGrid.Row && target.Column - 1 == chessGrid.Column) return true;
					break;
				case Directions.LeftDown:
					if (target.Row - 1 == chessGrid.Row && target.Column + 1 == chessGrid.Column) return true;
					break;
				case Directions.RightDown:
					if (target.Row - 1 == chessGrid.Row && target.Column - 1 == chessGrid.Column) return true;
					break;
				default:
					break;
			}
		}

		return false;
	}
}
