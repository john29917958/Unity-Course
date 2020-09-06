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
		}

		// Update is called once per frame
		void Update()
		{
			Debug.Log("Program updates");
		}
	}

}