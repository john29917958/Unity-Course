using System.Collections.Generic;
using UnityEngine;

public class Simple : MonoBehaviour {
	private List<int> _list = new List<int>();

	// Use this for initialization
	void Start () {
		for (int i = 1; i <= 10; i++)
		{
			_list.Add(i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			PrintList();
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			_list.Clear();
		}
		else
		{
			// Do nothing.
		}
	}

	private void PrintList()
	{
		string message = string.Empty;

		foreach (int i in _list)
		{
			message += i + ",";
		}

		message = message.TrimEnd(',');

		Debug.Log(message);
	}
}
