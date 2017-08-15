using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

public class QuestionDataTool : MonoBehaviour {

	public List<QuestionData> questionDataList = new List<QuestionData>();

	[ContextMenu("Save Question Data")]
	public void SaveQuestionData()
	{
		string json = JsonConvert.SerializeObject(questionDataList);

		string path = "Assets/Resources/GameDatas/QuestionData.json";

		using (FileStream fs = new FileStream(path, FileMode.Create))
		{
			using (StreamWriter writer = new StreamWriter(fs))
			{
				writer.Write(json);
			}
		}

#if UNITY_EDITOR
		UnityEditor.AssetDatabase.Refresh();
#endif
	}

	[ContextMenu("Load Question Data")]
	public void LoadQuestionData()
	{
		string path = "GameDatas/QuestionData";

		TextAsset ta = Resources.Load<TextAsset>(path);
		questionDataList = JsonConvert.DeserializeObject<List<QuestionData>>(ta.text);
	}

	[ContextMenu("Setup Question Ids")]
	public void SetupQuestionIDs()
	{
		for (int i = 0; i < questionDataList.Count; i++)
		{
			questionDataList[i].question = "Translate this sentence.";
		}
	}

	[ContextMenu("Check Answers Correct")]
	public void CheckAnswersCorrect()
	{
		for (int i = 0; i < questionDataList.Count; i++)
		{
			bool hasCorrect = false;
			int correctCount = 0;
			for (int j = 0; j < questionDataList[i].answers.Count; j++)
			{
				if (questionDataList[i].answers[j].isCorrect)
				{
					hasCorrect = true;
					correctCount++;
				}
			}
			if (hasCorrect == false)
			{
			}

			if (correctCount > 1)
			{
			}
		}

		Debug.Log("CheckAnswersCorrect");
	}
}
