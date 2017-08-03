using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

[System.Serializable]
public class QuestionLevelData
{
	public string name;
	public int stageID;
	public List<int> questionIDList = new List<int>();
}

public class QuestionLevelDataTable
{
	public Dictionary<int, QuestionLevelData> dataDic = new Dictionary<int, QuestionLevelData>();
	public List<QuestionLevelData> dataList;

	public bool isLoaded = false;

	public QuestionLevelData this[int stageID]
	{
		get
		{
			if (!isLoaded)
			{
				Load();
			}

			return dataDic[stageID];
		}
	}

	public void Load()
	{
		TextAsset ta = Resources.Load("GameDatas/QuestionLevelData") as TextAsset;

		dataList = JsonConvert.DeserializeObject<List<QuestionLevelData>>(ta.text);

		for (int i = 0; i < dataList.Count; i++)
		{
			if (!dataDic.ContainsKey(dataList[i].stageID))
			{
				dataDic.Add(dataList[i].stageID, dataList[i]);
			}
		}

		isLoaded = true;
	}
}
