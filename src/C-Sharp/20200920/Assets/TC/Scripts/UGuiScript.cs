using UnityEngine;
using UnityEngine.UI;

namespace TC
{
	public class UGUIScript : MonoBehaviour
	{
		public Button[] Buttons;
		public Image Image;
		public Text Text;
		public InputField NameInput;

		// Use this for initialization
		void Start()
		{
			foreach(Button button in Buttons)
			{
				button.onClick.AddListener(delegate ()
				{
					Text text = button.gameObject.GetComponentInChildren<Text>();
					OnButtonClicked(text.text);
				});
			}
		}

		// Update is called once per frame
		void Update()
		{

		}

		private void OnButtonClicked(string buttonText)
		{
			if (string.IsNullOrEmpty(NameInput.text))
			{
				Text.text = "Unknown - " + buttonText;
			}
			else
			{
				Text.text = NameInput.text + " - " + buttonText;
			}
		}
	}
}
