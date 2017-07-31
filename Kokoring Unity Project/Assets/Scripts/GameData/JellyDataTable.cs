using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

public class JellyData {

	public int id;
	public string name;
}

public class JellyDataTable
{
	public Dictionary<int, JellyData> data;

	public void Load()
	{
		TextAsset ta = Resources.Load("GameDatas/JellyData/JellyData") as TextAsset;

		data = JsonConvert.DeserializeObject<Dictionary<int, JellyData>>(ta.text);
	}
}
