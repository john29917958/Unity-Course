using UnityEngine;

public class Queue : MonoBehaviour {
	public Players Owner;
	public GameObject[] SlotPositions = new GameObject[4];
	public Chess[] Slots = new Chess[4];

	public bool AssignChess(Chess chess)
	{
		for (int i = 0; i < Slots.Length; i++)
		{
			if (Slots[i] == null)
			{
				Slots[i] = chess;
				chess.Grid.Chesses.Remove(chess);
				chess.Grid = null;
				chess.IsDead = true;
				chess.Owner = chess.Owner == Players.Player1 ? Players.Player2 : Players.Player1;
				chess.gameObject.transform.position = SlotPositions[i].transform.position;
				return true;
			}
		}

		return false;
	}

	public void ReviveChess(Chess chess, Grid grid)
	{
		for (int i = 0; i < Slots.Length; i++)
		{
			if (Slots[i] == chess)
			{
				Slots[i] = null;
				chess.Grid = grid;
				chess.IsDead = false;
				grid.Chesses.Add(chess);
				chess.gameObject.transform.position = grid.gameObject.transform.position;
				return;
			}
		}
	}
}
