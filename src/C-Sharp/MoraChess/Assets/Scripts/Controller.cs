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
			if (!IsMoveDirectionValid(ActionChess, grid))
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
			Debug.Log("Attack");
			//TODO: Checks and attacks enemy.
			SwitchRound();
		}
	}

	public void SwitchRound()
	{

	}

	// Use this for initialization
	void Start () {
		
	}
	
	private bool IsMoveDirectionValid(Chess chess, Grid target)
	{
		foreach (Directions direction in chess.AvailableMovementDirections)
		{
			switch (direction)
			{
				case Directions.Up:
					if (target.Row + 1 == chess.Grid.Row && target.Column == chess.Grid.Column) return true;
					break;
				case Directions.Down:
					if (target.Row - 1 == chess.Grid.Row && target.Column == chess.Grid.Column) return true;
					break;
				case Directions.Left:
					if (target.Row == chess.Grid.Row && target.Column + 1 == chess.Grid.Column) return true;
					break;
				case Directions.Right:
					if (target.Row == chess.Grid.Row && target.Column - 1 == chess.Grid.Column) return true;
					break;
				case Directions.LeftUp:
					Debug.Log(string.Format("Left up. Chess: {0}, {1}. Grid: {2}, {3}", chess.Grid.Row, chess.Grid.Column, target.Row, target.Column));
					if (target.Row + 1 == chess.Grid.Row && target.Column + 1 == chess.Grid.Column) return true;
					break;
				case Directions.RightUp:
					if (target.Row + 1 == chess.Grid.Row && target.Column - 1 == chess.Grid.Column) return true;
					break;
				case Directions.LeftDown:
					if (target.Row - 1 == chess.Grid.Row && target.Column + 1 == chess.Grid.Column) return true;
					break;
				case Directions.RightDown:
					if (target.Row - 1 == chess.Grid.Row && target.Column - 1 == chess.Grid.Column) return true;
					break;
				default:
					break;
			}
		}

		return false;
	}
}
