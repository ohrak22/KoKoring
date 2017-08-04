using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UI;

public class MapTool : MonoBehaviour
{
	public Transform mapRoot;
	public List<Sprite> mapImages;

	public GameObject defaultMap;
	public GameObject defaultStage;

	public List<StageLevelData> levelDataList;
	public List<Map> mapList;

	[ContextMenu("Setup Maps")]
	public void SetupMaps()
	{
		int stageNumber = 1;

		for (int i = 0; i < mapList.Count; i++)
		{
			if (mapList[i] == null)
			{
				GameObject go = Instantiate(defaultMap);
				go.transform.SetParent(mapRoot);
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				mapList[i] = go.GetComponent<Map>();
			}

			mapList[i].name = "Map " + (i + 1);
			mapList[i].transform.SetAsFirstSibling();
			mapList[i].GetComponent<Image>().sprite = mapImages[i % mapImages.Count];

			// Stage Button Setup.
			Map map = mapList[i].GetComponent<Map>();
			for (int stage = 0; stage < map.stageButtonList.Count; stage++)
			{
				if (map.stageButtonList[stage] == null)
				{
					GameObject go = Instantiate(defaultStage);
					go.transform.SetParent(map.transform);
					Vector3 pos = Vector3.zero;
					pos.y = stage * 100;
					go.transform.localPosition = pos;
					go.transform.localScale = Vector3.one;
					map.stageButtonList[stage] = go.GetComponent<StageButton>();
				}

				map.stageButtonList[stage].Setup(stageNumber, defaultStage.GetComponent<StageButton>());
				stageNumber++;

			}

		}
		
	}
	
}
