using System;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
	public KeyCode ActivationKey;
	public Text Health;
	public Text ChallengedCount;
	public Text Counter;
	public Text TargetTime;
	public Text Message;

	private bool _isEnded = false;
	private int _health = 5;
	private int _challengedCount = 0;
	private float _counter = 0;
	private int _targetTime = 10;

	// Use this for initialization
	void Start () {
		Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		if (_isEnded) return;

		if (Input.GetKeyDown(ActivationKey))
		{
			_challengedCount += 1;
			_counter = 0;
			_targetTime = UnityEngine.Random.Range(5, 15);

			RefreshMessage();
		}
		else if (Input.GetKey(ActivationKey))
		{
			_counter += Time.deltaTime;

			RefreshMessage(string.Format("請放開鍵盤 {0} - 停止", ActivationKey.ToString()), false);
		}
		else if (Input.GetKeyUp(ActivationKey))
		{
			int diff = Convert.ToInt32(Math.Abs(_counter - _targetTime));			

			if (diff != 0)
			{
				_health -= 1;
			}

			if (_health < 0) _health = 0;
			if (_health == 0) _isEnded = true;

			RefreshMessage(string.Format("與目標秒差：{0}" + (_isEnded ? " (遊戲結束)" : string.Empty), diff));
		}
		else
		{
			// Do nothing if pressed key is not "A".
		}
	}

	private void Initialize()
	{
		_isEnded = false;
		_health = 5;
		_challengedCount = 0;
		_counter = 0;
		_targetTime = 10;

		RefreshMessage(string.Format("請按住鍵盤 {0} - 開始", ActivationKey.ToString()));
	}

	private void RefreshMessage(string message = null, bool updateCounter = true)
	{
		Health.text = string.Format("玩家血量：{0}", _health);
		ChallengedCount.text = string.Format("遊戲次數：{0}", _challengedCount);		
		TargetTime.text = string.Format("目標時間：{0}", _targetTime);

		if (updateCounter) Counter.text = string.Format("計時器：{0}", Math.Round(_counter));
		if (!string.IsNullOrEmpty(message)) Message.text = message;
	}
}
