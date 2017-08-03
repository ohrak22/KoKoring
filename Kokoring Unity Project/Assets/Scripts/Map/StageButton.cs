using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class StageButton : MonoBehaviour {

	public int stageID;
	public Text stageNumber;
	public List<GameObject> stars;
	
	void Start()
	{
		UserData userData = GameDataManager.Instance.userData;
		int starCount = 0;

		if (userData.clearStageDic.ContainsKey(stageID))
		{
			GetComponent<Image>().color = Color.green;
			GetComponent<Button>().interactable = true;

			starCount = userData.clearStageDic[stageID].starCount;

		}
		else if (userData.currentStage == stageID)
		{
			GetComponent<Image>().color = Color.green;
			GetComponent<Button>().interactable = true;
		}
		else
		{
			GetComponent<Image>().color = Color.gray;
			GetComponent<Button>().interactable = false;
		}

		for (int i = 0; i < 3; i++)
		{
			stars[i].SetActive(false);
		}

		if (starCount > 0)
		{
			stars[starCount - 1].SetActive(true);
		}
	}

	public void SetupForMapTool(StageLevelData data, bool currentStage = false)
	{
		name = data.stageName;
		stageID = data.id;
		stageNumber.text = data.id.ToString();

		for (int i = 0; i < 3; i++)
		{
			stars[i].SetActive(false);
		}

		if (data.starCount > 0)
		{
			stars[data.starCount - 1].SetActive(true);
		}

		if (data.starCount > 0 || currentStage)
		{
			GetComponent<Image>().color = Color.green;
		}
		else
		{
			GetComponent<Image>().color = Color.grey;
		}
	}

	public void Click()
	{
		GlobalVeriables.curStageID = stageID;

		SceneManager.LoadScene("Play");
	}
}
