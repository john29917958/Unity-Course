using UnityEngine;
using UnityEngine.UI;

namespace TC
{
	public class UGUIScript : MonoBehaviour
	{
		public Button Button;
		public Image Image;
		public Text Text;
		public InputField Input;

		// Use this for initialization
		void Start()
		{
			Button.onClick.AddListener(OnButtonClicked);
		}

		// Update is called once per frame
		void Update()
		{

		}

		private void OnButtonClicked()
		{
			if (string.IsNullOrEmpty(Input.text))
			{
				Debug.Log("You didn't enter anyting!");
			}
			else
			{
				Debug.Log(Input.text);
			}
		}
	}
}
