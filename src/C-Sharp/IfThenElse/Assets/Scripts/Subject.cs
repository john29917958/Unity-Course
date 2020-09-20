using System;
using UnityEngine;
using UnityEngine.UI;

public class Subject : MonoBehaviour {
	public Text SubjectName;
	public InputField ScoreInput;
	public Toggle IsMainSubjectToggle;

	public string Name
	{
		get
		{
			return SubjectName.text;
		}
	}

	public double Score
	{
		get
		{
			double score = Convert.ToDouble(ScoreInput.text);

			if (score > 100) score = 100;

			return score;
		}
	}

	public double WeightedScore
	{
		get
		{
			double score = Convert.ToDouble(ScoreInput.text);
			
			if (IsMainSubject) score += score * 0.3;

			if (score > 100) score = 100;

			return score;
		}
	}

	public bool IsMainSubject
	{
		get
		{
			return IsMainSubjectToggle.isOn;
		}
	}
}
