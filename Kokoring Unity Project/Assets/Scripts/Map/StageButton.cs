using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class StageButton : MonoBehaviour, IComparable<StageButton> {

	public int stageID;
	public Text stageNumber;
	public List<GameObject> stars;
	
	public void Setup(StageLevelData data, bool currentStage = false)
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
	
	public int CompareTo(StageButton other)
	{
		if (this.stageID > other.stageID)
		{
			return 1;
		}
		else if (this.stageID < other.stageID)
		{
			return -1;
		}
		else
		{
			return 0;
		}
	}
}
