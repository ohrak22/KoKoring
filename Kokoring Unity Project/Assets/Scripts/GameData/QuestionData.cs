using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;

[System.Serializable]
public class QuestionData
{
	public enum QuestionType
	{
		Translate,
		Which_of_these,
		What_is_this,
	}

	public string sentence;
	public int questionID;
	public QuestionType type;
	public List<AnswerData> answers;
}

public class QuestionDataTable
{
	public Dictionary<int, QuestionData> dataDic = new Dictionary<int, QuestionData>();
	public List<QuestionData> dataList;
	public bool isLoaded = false;

	public QuestionData this[int questionID]
	{
		get
		{
			if (!isLoaded)
			{
				Load();
			}

			return dataDic[questionID];
		}
	}

	public void Load()
	{
		TextAsset ta = Resources.Load("GameDatas/QuestionData") as TextAsset;

		dataList = JsonConvert.DeserializeObject<List<QuestionData>>(ta.text);

		for (int i = 0; i < dataList.Count; i++)
		{
			if (!dataDic.ContainsKey(dataList[i].questionID))
			{
				dataDic.Add(dataList[i].questionID, dataList[i]);
			}
		}

		isLoaded = true;

	}
}