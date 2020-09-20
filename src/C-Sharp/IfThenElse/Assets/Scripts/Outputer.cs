using UnityEngine;
using UnityEngine.UI;

public class Outputer : MonoBehaviour {
	public Text Output;
	public int UpperBound = 10;
	public int LowerBound = 0;
	public int Index = 0;
	public bool ShouldCountDownward = false;

	private bool _isIncreasing = true;
	
	// Update is called once per frame
	void Update () {
		Output.text = Index.ToString();

		if (Index < UpperBound && _isIncreasing)
		{
			Index += 1;
			if (Index == UpperBound) _isIncreasing = false;
		}
		else if (Index > LowerBound && ShouldCountDownward)
		{
			Index -= 1;
		}
	}
}
