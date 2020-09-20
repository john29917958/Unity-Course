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
		public Sprite Logo;

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
				Text.text = "Nothing is entered!";
			}
			else
			{
				Text.text = Input.text;
			}

			Image.sprite = Logo;
		}
	}
}
