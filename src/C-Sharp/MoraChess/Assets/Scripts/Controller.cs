using UnityEngine;

public class Controller : MonoBehaviour {
	public enum RoundPhases { SetActionChess, Action }

	public Players RoundOwner = Players.Player1;
	public RoundPhases Phase;
	public Chess ActionChess;

	public void OnClick(Grid grid)
	{
		Debug.Log("On Grid Clicked");

		if (Phase == RoundPhases.Action)
		{
			Debug.Log("Moves chess");

			ActionChess.Grid.Chesses.Remove(ActionChess);
			ActionChess.Grid = grid;
			grid.Chesses.Add(ActionChess);
			ActionChess.gameObject.transform.position = grid.gameObject.transform.position;

			SwitchRound();
		}
	}

	public void OnClick(Chess chess)
	{
		Debug.Log("On Chess Clicked");

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
	
	// Update is called once per frame
	void Update () {
		
	}
}
