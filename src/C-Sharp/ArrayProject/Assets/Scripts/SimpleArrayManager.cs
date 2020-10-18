using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleArrayManager : MonoBehaviour {
	public Text Message;
	private List<string> _dynamicArray;

	// Use this for initialization
	void Start () {
		_dynamicArray = new List<string>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.D))
		{
			_dynamicArray.Clear();
			_dynamicArray.Add("A");
			_dynamicArray.Add("B");
			_dynamicArray.Add("C");
		}
		else if (Input.GetKeyDown(KeyCode.Space))
		{
			Message.text = string.Join(", ", _dynamicArray.ToArray());
		}
		else
		{
			// Do nothing.
		}
	}
}
