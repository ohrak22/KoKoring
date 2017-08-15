using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlayScene : MonoBehaviour
{
	public HeartPanel heartPanel;
	public QuestionPanel questionPanel;
	public AnswerPanel answerPanel;
	public MessageBox messageBox;
	public ResultPanel resultPanel;

	StageLevelData levelData;
	public int roundIndex = 0;
	public int failCount = 0;

	void Start()
	{
		Init();
		RoundStart();
	}

	public void Init()
	{
		GameController.Instance.playScene = this;
		failCount = 0;
		roundIndex = 0;
		levelData = GameDataManager.Instance.questionLevelTable[GlobalVeriables.curStageID];
		heartPanel.Init();
	}

	public void ClearQuestion()
	{
		messageBox.Hide();
		questionPanel.Clear();
		answerPanel.Clear();
	}

	public void RoundStart()
	{
		ClearQuestion();
		SetupQuestion();
	}

	public void NextRound()
	{
		ClearQuestion();
		SetupQuestion();
	}

	public void SetupQuestion()
	{
		questionPanel.Setup(levelData.roundList[roundIndex]);
		answerPanel.Setup(levelData.roundList[roundIndex]);
		roundIndex++;
	}
	
	public void ShowCompletedResult()
	{
		ClearQuestion();
		ResultData data = new ResultData();
		data.titleText = "Level " + GlobalVeriables.curStageID;
		data.contextText = "Level Completed!";
		data.buttonText = "Continue";
		data.starCount = 3 - failCount;
		resultPanel.Show(data);
	}

	public void ShowFailedResult()
	{
		ClearQuestion();
		ResultData data = new ResultData();
		data.titleText = "Level " + GlobalVeriables.curStageID;
		data.contextText = "Level Failed!";
		data.buttonText = "Try Again";
		data.starCount = 0;
		resultPanel.Show(data);
	}

	IEnumerator Correct()
	{
		answerPanel.BlockButtons();
		messageBox.Show("correct!.", Color.green);
		
		yield return new WaitForSeconds(2f);

		if (levelData.roundList.Count > roundIndex)
		{
			NextRound();
		}
		else
		{
			ShowCompletedResult();
		}
	}

	IEnumerator NotCorrect()
	{
		answerPanel.BlockButtons();
		messageBox.Show("It is not the correct answer.", Color.red);
		heartPanel.DecreaseHeart();

		yield return new WaitForSeconds(2f);

		failCount++;
		if (failCount >= 3)
		{
			ShowFailedResult();
		}
		else
		{
			answerPanel.UnblockButtons();
		}

	}

	public void ShowMessageBox(string message)
	{
		messageBox.Show(message, Color.red);
	}

	public void ClickAnswerButton(AnswerData answerData)
	{
		questionPanel.SetAnswerText(answerData.answer, answerData.isCorrect);

		if (answerData.isCorrect)
		{
			StartCoroutine(Correct());
		}
		else
		{
			StartCoroutine(NotCorrect());
		}
	}

	public void ClickBack()
	{
		SceneManager.LoadScene("Map");
	}

	
}
