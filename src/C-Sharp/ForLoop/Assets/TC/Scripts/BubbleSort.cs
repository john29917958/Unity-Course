using UnityEngine;

public class BubbleSort : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[] list = new int[10];

		for (int i = 0; i < list.Length; i++)
		{
			list[i] = Random.Range(0, 101);
		}

		bool isSorted = true;
		while (isSorted)
		{
			isSorted = false;

			for (int i = 0; i < list.Length - 1; i++)
			{
				if (list[i] > list[i + 1])
				{
					int temp = list[i];
					list[i] = list[i + 1];
					list[i + 1] = temp;
					isSorted = true;
				}
			}
		}

		string message = string.Empty;
		for (int i = 0; i < list.Length; i++)
		{
			message += list[i].ToString() + ',';
		}
		Debug.Log(message);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
