using System;
using UnityEngine;

public class Normal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PrintQuiz1Result();
		PrintQuiz2Result();
		PrintOddNumbers();
		Print99MultiplyTable();
	}

	private void PrintQuiz1Result()
	{
		string message = string.Empty;
		for (int i = 0; i < 10; i++)
		{
			message += i.ToString() + ',';
		}
		message = message.TrimEnd(',');
		Debug.Log(message);
	}

	private void PrintQuiz2Result()
	{
		string message = string.Empty;
		for (int i = 9; i >= 0; i--)
		{
			message += i.ToString() + ',';
		}
		message = message.TrimEnd(',');
		Debug.Log(message);
	}

	private void PrintOddNumbers()
	{
		string message = string.Empty;
		for (int i = 0; i < 16; i++)
		{
			if (i % 2 != 0)
			{
				message += i.ToString() + ',';
			}
		}
		message = message.TrimEnd(',');
		Debug.Log(message);
	}

	private void Print99MultiplyTable()
	{
		string message = string.Empty;
		for (int i = 1; i < 10; i++)
		{
			for (int j = 1; j < 10; j++)
			{
				message = string.Format("{0}x{1}={2}", i, j, i * j);
				Debug.Log(message);
			}
		}		
	}
}
