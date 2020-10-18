using System;
using UnityEngine;

public class PrintStars : MonoBehaviour {
	public int Size = 5;

	// Use this for initialization
	void Start () {
		PrintStars1();
		PrintStars2();
		PrintStars3();
		PrintStars4();
		PrintStars5();
		PrintStars6();
		PrintStars7();
	}

	private void PrintStars1()
	{
		string message = string.Empty;
		for (int i = 0; i < Size; i++)
		{
			for (int j = 0; j < Size; j++)
			{
				if (j <= i)
				{
					message += '★';
				}
				else
				{
					message += "  ";
				}
			}
			message += Environment.NewLine;
		}

		if (message.EndsWith(Environment.NewLine))
		{
			message = message.Substring(0, message.Length - Environment.NewLine.Length);
		}

		Debug.Log(message);
	}

	private void PrintStars2()
	{
		string message = string.Empty;
		for (int i = 0; i < Size; i++)
		{
			for (int j = 0; j < Size; j++)
			{
				if (Size - 1 - j <= i)
				{
					message += '★';
				}
				else
				{
					message += "  ";
				}
			}
			message += Environment.NewLine;
		}

		if (message.EndsWith(Environment.NewLine))
		{
			message = message.Substring(0, message.Length - Environment.NewLine.Length);
		}

		Debug.Log(message);
	}

	private void PrintStars3()
	{
		string message = string.Empty;
		for (int i = 0; i < Size; i++)
		{
			for (int j = 0; j < Size; j++)
			{
				if (Size - 1 - j >= i)
				{
					message += '★';
				}
				else
				{
					message += "  ";
				}
			}
			message += Environment.NewLine;
		}

		if (message.EndsWith(Environment.NewLine))
		{
			message = message.Substring(0, message.Length - Environment.NewLine.Length);
		}

		Debug.Log(message);
	}

	private void PrintStars4()
	{
		string message = string.Empty;
		for (int i = 0; i < Size; i++)
		{
			for (int j = 0; j < Size; j++)
			{
				if (j >= i)
				{
					message += '★';
				}
				else
				{
					message += "  ";
				}
			}
			message += Environment.NewLine;
		}

		if (message.EndsWith(Environment.NewLine))
		{
			message = message.Substring(0, message.Length - Environment.NewLine.Length);
		}

		Debug.Log(message);
	}

	private void PrintStars5()
	{
		string message = string.Empty;
		for (int i = 0; i < Size; i++)
		{
			for (int j = 0; j < Size; j++)
			{
				if (i <= Size / 2)
				{
					if (j <= i)
					{
						message += '★';
					}
					else
					{
						message += "  ";
					}
				}
				else
				{
					if (Size - 1 - j >= i)
					{
						message += '★';
					}
					else
					{
						message += "  ";
					}
				}				
			}

			message += Environment.NewLine;
		}
		Debug.Log(message);
	}

	private void PrintStars6()
	{
		string message = string.Empty;
		for (int i = 0; i < Size; i++)
		{
			for (int j = 0; j < Size; j++)
			{
				if (i <= Size / 2)
				{
					if (Size - 1 - j <= i)
					{
						message += '★';
					}
					else
					{
						message += "  ";
					}
				}
				else
				{
					if (j >= i)
					{
						message += '★';
					}
					else
					{
						message += "  ";
					}
				}
			}

			message += Environment.NewLine;
		}
		Debug.Log(message);
	}

	private void PrintStars7()
	{
		string message = string.Empty;
		for (int i = 0; i < Size; i++)
		{
			for (int j = 0; j < Size; j++)
			{
				if (Math.Abs(j - Size/2) <= i)
				{
					message += '★';
				}
				else
				{
					message += "  ";
				}
			}

			message += Environment.NewLine;
		}

		Debug.Log(message);
	}
}
