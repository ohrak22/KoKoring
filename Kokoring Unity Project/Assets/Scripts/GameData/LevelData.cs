using UnityEngine;
using System.Collections;
using Newtonsoft.Json;

public class LevelData {

	public int[,] data;

	public void Load()
	{
		TextAsset ta = Resources.Load("GameDatas/LevelData/Level1") as TextAsset;

		data = JsonConvert.DeserializeObject<int[,]>(ta.text);
	}
}
