using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvancedScoreJudgingSystem : MonoBehaviour {
	public Subject[] Subjects;
	public Text ResultText;

	public void Judge()
	{
		Subject mainSubject = null;

		foreach (Subject subject in Subjects)
		{
			if (subject.IsMainSubject)
			{
				mainSubject = subject;
			}
		}

		string judgeReuslt = "加權前, 組別 - " + mainSubject.Name + ", 分數 - ";
		List<string> scoreResults = new List<string>();
		foreach (Subject subject in Subjects)
		{
			try
			{
				scoreResults.Add(subject.Name + " : " + subject.Score + "(" + (IsPass(subject) ? "及格" : "不及格") + ")");
			}
			catch(Exception)
			{
				ResultText.text = subject.Name + "分數格式輸入錯誤！";
				return;
			}
		}
		judgeReuslt += string.Join(", ", scoreResults.ToArray());

		string weightedJudgeResult = "加權後, 組別 - " + mainSubject.Name + ", 分數 - ";
		scoreResults.Clear();
		foreach (Subject subject in Subjects)
		{
			try
			{
				scoreResults.Add(subject.Name + " : " + subject.WeightedScore + "(" + (IsPass(subject, true) ? "及格" : "不及格") + ")");
			}
			catch (Exception)
			{
				ResultText.text = subject.Name + "分數格式輸入錯誤！";
				return;
			}
		}
		weightedJudgeResult += string.Join(", ", scoreResults.ToArray());

		ResultText.text = judgeReuslt + Environment.NewLine + weightedJudgeResult;
	}

	private bool IsPass(Subject subject, bool isWeighted = false)
	{
		double score = subject.IsMainSubject ? subject.Score : subject.WeightedScore;

		return score >= 60;
	}
}
