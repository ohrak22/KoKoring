using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;

[System.Serializable]
public class QuestionData
{
	public string sentence;
	public string question;
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
		
		isLoaded = true;
	}
}