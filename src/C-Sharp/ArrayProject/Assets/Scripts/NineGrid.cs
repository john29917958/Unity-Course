using UnityEngine;
using UnityEngine.UI;

public class NineGrid : MonoBehaviour {
	public Text Message;
	public Button RestartButton;
	public enum Players { None, Circle, Cross };
	public Players[,] CheckResult;

	public Players Player = Players.Circle;

	private bool _isEnded = false;

	public string PlayerIcon
	{
		get
		{
			if (Player == Players.Circle)
			{
				return "O";
			}
			else if (Player == Players.Cross)
			{
				return "X";
			}
			else
			{
				return string.Empty;
			}
		}
	}

	public void SetGridValue(int row, int col)
	{
		if (_isEnded) return;

		CheckResult[row, col] = Player;			
		Judge();
	}

	public void Judge()
	{
		for (int i = 0; i < 3; i++)
		{
			if (IsConnected(CheckResult[i, 0], CheckResult[i, 1], CheckResult[i, 2]))
			{
				Message.text = string.Format("{0} 獲勝！", PlayerIcon);
				EndsGame();
				return;
			}

			if (IsConnected(CheckResult[0, i], CheckResult[1, i], CheckResult[2, i]))
			{
				Message.text = string.Format("{0} 獲勝！", PlayerIcon);
				EndsGame();
				return;
			}
		}

		if (IsConnected(CheckResult[0, 0], CheckResult[1, 1], CheckResult[2, 2]))
		{
			Message.text = string.Format("{0} 獲勝！", PlayerIcon);
			EndsGame();
			return;
		}

		if (IsConnected(CheckResult[0, 2], CheckResult[1, 1], CheckResult[2, 0]))
		{
			Message.text = string.Format("{0} 獲勝！", PlayerIcon);
			EndsGame();
			return;
		}

		if (!IsAnyGridAvailable())
		{
			Message.text = "和局";
			EndsGame();
			return;
		}

		if (Player == Players.Circle)
		{
			Player = Players.Cross;
		}
		else
		{
			Player = Players.Circle;
		}

		Message.text = string.Format("輪到 {0}", PlayerIcon);
	}

	// Use this for initialization
	void Start () {
		Restart();
	}

	public void Restart()
	{
		Player = Players.Circle;
		CheckResult = new Players[3, 3];
		_isEnded = false;
		RestartButton.gameObject.SetActive(false);

		Message.text = string.Format("輪到 {0}", PlayerIcon.ToString());

		foreach (Button button in GetComponentsInChildren<Button>())
		{			
			button.interactable = true;
			button.GetComponentInChildren<Text>().text = string.Empty;
		}
	}

	private void EndsGame()
	{
		_isEnded = true;
		RestartButton.gameObject.SetActive(true);

		foreach (Button button in GetComponentsInChildren<Button>())
		{
			button.interactable = false;
		}
	}

	private bool IsAnyGridAvailable()
	{
		foreach (Button button in GetComponentsInChildren<Button>())
		{
			if (button.interactable) return true;
		}

		return false;
	}

	private bool IsConnected(params Players[] players)
	{
		foreach (Players player in players)
		{
			if (player == Players.None) return false;
		}

		for (int i = 0; i < players.Length - 1; i++)
		{
			if (players[i] != players[i + 1]) return false;
		}

		if (players[0] != players[players.Length - 1]) return false;

		return true;
	}
}
