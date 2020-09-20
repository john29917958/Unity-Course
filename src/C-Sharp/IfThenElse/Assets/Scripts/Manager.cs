using System;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
	public Text TipText;
	public Text TriesText;
	public InputField GuessText;
	public Button SubmitButton;

	private int start, end;
	private int _answerNumber;
	
	public void ReStart()
	{
		start = 1;
		end = 100;
		_answerNumber = UnityEngine.Random.Range(0, 101);

		TipText.text = "1~100";
		TriesText.text = "0";
		GuessText.text = string.Empty;
	}

	public void Check()
	{
		if (SubmitButton.gameObject.GetComponentInChildren<Text>().text == "重新開始")
		{
			SubmitButton.gameObject.GetComponentInChildren<Text>().text = "確認";
			ReStart();
			return;
		}		

		int guess = 0;

		try
		{
			guess = Convert.ToInt32(GuessText.text);
		}
		catch(Exception)
		{
			TipText.text = start + "~" + end + "輸入數字格式不符！";
			return;
		}

		if (guess == _answerNumber)
		{
			TipText.text = "Bingo！「" + _answerNumber + "」";
			SubmitButton.gameObject.GetComponentInChildren<Text>().text = "重新開始";
			return;
		}

		if (guess > _answerNumber)
		{
			end = guess;
		}
		else
		{
			start = guess;
		}

		TipText.text = start + "~" + end;
		TriesText.text = (Convert.ToInt32(TriesText.text) + 1).ToString();
	}

	void Start()
	{
		ReStart();
	}
}
