using UnityEngine;

namespace tc
{
	public class Manager : MonoBehaviour
	{
		public int Number = 10;
		public float RealNumber = 0.5f;
		public bool Flag = true;
		public string Message = "Hello World!";

		// Use this for initialization
		void Start()
		{
			Debug.Log("Program starts");

			Number = 3 + 7;
			Number = 15 - 5;
			Number = 5 * 2;
			Number = 20 / 2;
			Number = 110 % 100;

			Number += 5;
			Number -= 5;
			Number *= 5;
			Number /= 5;
			Number %= 3;

			Number++;
			Number--;
		}

		// Update is called once per frame
		void Update()
		{
			Debug.Log("Program updates");
		}
	}

}