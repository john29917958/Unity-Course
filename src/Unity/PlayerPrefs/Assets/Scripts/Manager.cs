using System;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
	public InputField Name;
	public InputField Level;
	public InputField Experience;

	public void SaveData()
    {
		string name = Name.text;
		int level = Convert.ToInt32(Level.text);
		float experience = float.Parse(Experience.text);

		Config config = Config.Load();		

		config.Name = name;
		config.Level = level;
		config.Experience = experience;
		config.Save();
	}
	
	private void Start()
    {
		Config config = Config.Load();
		Name.text = config.Name;
		Level.text = config.Level.ToString();
		Experience.text = config.Experience.ToString();
    }
	
	private void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space))
        {
			Config config = Config.Load();			

			Debug.Log("Config:");
			Debug.Log("Name: " + config.Name);
			Debug.Log("Level: " + config.Level);
			Debug.Log("Experience: " + config.Experience);
        }
	}
}
