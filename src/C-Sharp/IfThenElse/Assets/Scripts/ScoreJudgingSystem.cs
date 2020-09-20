using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreJudgingSystem : MonoBehaviour {
	public InputField ScoreInput;
	public Text JudgeResultText;


	public void Judge()
	{
		try
		{
			double score = Convert.ToDouble(ScoreInput.text);

			if (score >= 100)
			{
				JudgeResultText.text = "恭喜你，滿分通過";
			}
			else if (score >= 80 && score <= 99)
			{
				JudgeResultText.text = "你很優秀，繼續保持";
			}
			else if (score >= 60 && score <= 79)
			{
				JudgeResultText.text = "成績良好";
			}
			else if (score >= 50 && score <= 59)
			{
				JudgeResultText.text = "就差一點，下次一定要及格";
			}
			else
			{
				JudgeResultText.text = "沒救了";
			}
		}
		catch (Exception e)
		{
			JudgeResultText.text = "輸入分數格式錯誤！";
		}
	}
}
