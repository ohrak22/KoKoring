using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

public class MapTool : MonoBehaviour {

	public List<StageLevelData> levelDataList;
	public List<Map> MapList;

	[ContextMenu("Setup Maps")]
	public void SetupMaps()
	{
		int index = 0;
		int lastStar = 0;

		foreach (Map map in MapList)
		{
			foreach (StageButton stage in map.stageButtonList)
			{
				if (levelDataList.Count <= index)
				{
					AddLevelData();
				}

				if (lastStar > 0 && levelDataList[index].starCount == 0)
				{
					stage.Setup(levelDataList[index], true);
				}
				else
				{
					stage.Setup(levelDataList[index]);
				}

				lastStar = levelDataList[index].starCount;
				index++;
			}
		}
	}

	[ContextMenu("Add Level Data")]
	public void AddLevelData()
	{
		StageLevelData data = new StageLevelData();
		data.id = levelDataList.Count + 1;
		data.stageName = "Stage " + data.id;

		levelDataList.Add(data);
	}

	[ContextMenu("Add Level Data x 10")]
	public void AddLevelDataTen()
	{
		for (int i = 0; i < 10; i++)
		{
			StageLevelData data = new StageLevelData();
			data.id = levelDataList.Count + 1;
			data.stageName = "Stage " + data.id;

			levelDataList.Add(data);
		}
	}

	[ContextMenu("Load Level Data")]
	public void LoadLevelData()
	{
		TextAsset ta = Resources.Load("GameDatas/StageLevelData") as TextAsset;

		levelDataList = JsonConvert.DeserializeObject<List<StageLevelData>>(ta.text);
	}

	[ContextMenu("Save Level Data")]
	public void SaveLevelData()
	{
		string json = JsonConvert.SerializeObject(levelDataList);

		string path = "Assets/Resources/GameDatas/StageLevelData.json";

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
}
