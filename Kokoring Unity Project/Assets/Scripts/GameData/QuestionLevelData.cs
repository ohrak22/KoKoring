using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

[System.Serializable]
public class StageLevelData
{
	public string name;
	public int stageID;
	public List<QuestionData> roundList = new List<QuestionData>();
}

public class QuestionLevelDataTable
{
	public Dictionary<int, StageLevelData> dataDic = new Dictionary<int, StageLevelData>();
	public List<StageLevelData> dataList;

	public bool isLoaded = false;

	public StageLevelData this[int stageID]
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
		TextAsset ta = Resources.Load("GameDatas/LevelData") as TextAsset;

		dataList = JsonConvert.DeserializeObject<List<StageLevelData>>(ta.text);

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
