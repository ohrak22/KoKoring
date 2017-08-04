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

	public void Setup(int stageNum, StageButton defaultButton)
	{
		name = "Stage " + stageNum;
		stageNumber.text = stageNum.ToString();
		stageNumber.font = defaultButton.stageNumber.font;
		stageNumber.resizeTextForBestFit = defaultButton.stageNumber.resizeTextForBestFit;
		stageNumber.GetComponent<RectTransform>().sizeDelta = defaultButton.stageNumber.GetComponent<RectTransform>().sizeDelta;

	}
	
	public void Click()
	{
		GlobalVeriables.curStageID = stageID;

		SceneManager.LoadScene("Play");
	}

}
