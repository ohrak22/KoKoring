using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

public class LevelTool : MonoBehaviour
{

	public List<StageLevelData> levelList = new List<StageLevelData>();

	[ContextMenu("Load Level Data")]
	public void LoadLevelData()
	{
		string path = "GameDatas/LevelData";
		TextAsset ta = Resources.Load<TextAsset>(path);
		levelList = JsonConvert.DeserializeObject<List<StageLevelData>>(ta.text);
	}


	[ContextMenu("Save Level Data")]
	public void SaveLevelData()
	{
		string json = JsonConvert.SerializeObject(levelList);

		string path = "Assets/Resources/GameDatas/LevelData.json";

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

	[ContextMenu("Setup Level Data")]
	public void SetupLevelData()
	{
		for (int i = 0; i < levelList.Count; i++)
		{
			levelList[i].name = "Level " + (i + 1);
			levelList[i].stageID = i + 1;
		}
	}

	[ContextMenu("Check Correct Level Data")]
	public void CheckCorrect()
	{
		foreach (StageLevelData level in levelList)
		{
			foreach (QuestionData round in level.roundList)
			{
				int correctCount = 0;
				foreach (AnswerData answer in round.answers)
				{
					if (answer.isCorrect)
						correctCount++;
				}
				if (correctCount == 0)
				{
					Debug.Log(level.name);
					Debug.Log(round.question);
					Debug.Log("correctCount: " + correctCount);
				}
				else if (correctCount > 1)
				{
					Debug.Log(level.name);
					Debug.Log(round.question);
					Debug.Log("correctCount: " + correctCount);
				}
			}
		}
	}

	[ContextMenu("Shuffle Answer")]
	public void ShuffleAnswer()
	{
		foreach (StageLevelData level in levelList)
		{
			foreach (QuestionData round in level.roundList)
			{
				int n = round.answers.Count;
				while (n > 1)
				{
					n--;
					int k = Random.Range(0, n + 1);
					AnswerData value = round.answers[k];
					round.answers[k] = round.answers[n];
					round.answers[n] = value;
				}
			}
		}
	}
}
