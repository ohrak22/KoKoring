using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultData
{
	public string titleText;
	public string contextText;
	public string buttonText;
	public int starCount;
}

public class ResultPanel : MonoBehaviour {

	public Text titleText;
	public Text context;
	public GameObject[] stars;
	public Text ButtonText;
	public ResultData resultData;

	public void Show(ResultData data)
	{
		gameObject.SetActive(true);

		if (data.starCount > 0)
		{
			UserStageData stage = new UserStageData();
			stage.stageKey = GlobalVeriables.curStageID;
			stage.starCount = data.starCount;

			GameDataManager.Instance.userData.clearStageDic.Add(stage.stageKey, stage);
			GameDataManager.Instance.userData.currentStage = stage.stageKey + 1;

			GameDataManager.Instance.SaveUserData();
		}

		resultData = data;
		titleText.text = data.titleText;
		context.text = data.contextText;
		ButtonText.text = data.buttonText;
		for (int i = 0; i < stars.Length; i++)
		{
			if (data.starCount > i)
			{
				stars[i].SetActive(true);
			}
			else
			{
				stars[i].SetActive(false);
			}
		}
	}

	public void ClickClose()
	{
		if (resultData.starCount > 0)
		{
			GlobalVeriables.mapStatus = MapEntryStatus.StageClear;
		}
		else
		{
			GlobalVeriables.mapStatus = MapEntryStatus.StageFailed;
		}

		SceneManager.LoadScene("Map");
	}

	public void ClickResultButton()
	{
		if (resultData.starCount > 0)
		{
			GlobalVeriables.mapStatus = MapEntryStatus.StageClear;
			SceneManager.LoadScene("Map");
		}
		else
		{
			SceneManager.LoadScene("Play");
		}

	}
}
