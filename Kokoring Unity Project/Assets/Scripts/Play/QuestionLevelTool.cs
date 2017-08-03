using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

public class QuestionLevelTool : MonoBehaviour {

	public List<QuestionLevelData> questionLevelList = new List<QuestionLevelData>();

	[ContextMenu("Save Question Level Data")]
	public void SaveQuestionLevelData()
	{
		string json = JsonConvert.SerializeObject(questionLevelList);

		string path = "Assets/Resources/GameDatas/QuestionLevelData.json";

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

	[ContextMenu("Auto Setup Question Level Data")]
	public void AutoSetupQuestionLevelData()
	{
		for (int i = questionLevelList.Count; i < 100; i++)
		{
			QuestionLevelData data = new QuestionLevelData();
			data.name = "Stage " + (i + 1);
			data.stageID = (i + 1);

			for (int id = (i * 10) + 1; id <= (i * 10) + 10; id++)
			{
				data.questionIDList.Add(id);
			}

			questionLevelList.Add(data);
		}
	}
}
