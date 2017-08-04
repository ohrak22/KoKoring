using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlayScene : MonoBehaviour
{
	public QuestionPanel questionPanel;
	public AnswerPanel answerPanel;
	public MessageBox messageBox;
	public ResultPanel resultPanel;

	QuestionLevelData levelData;
	public Queue<int> questionIDs;
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
		QuestionLevelData levelData = GameDataManager.Instance.questionLevelTable[GlobalVeriables.curStageID];
		questionIDs = new Queue<int>(levelData.questionIDList);
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
		SetupQuestion(questionIDs.Dequeue());
	}

	public void NextRound()
	{
		ClearQuestion();
		SetupQuestion(questionIDs.Dequeue());
	}

	public void SetupQuestion(int questionID)
	{
		QuestionData questionData = GameDataManager.Instance.questionTable[questionID];
		questionPanel.Setup(questionData);
		answerPanel.Setup(questionData);
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

		NextRound();
	}

	IEnumerator NotCorrect()
	{
		answerPanel.BlockButtons();
		messageBox.Show("It is not the correct answer.", Color.red);

		yield return new WaitForSeconds(2f);

		answerPanel.UnblockButtons();

	}

	public void ShowMessageBox(string message)
	{
		messageBox.Show(message, Color.red);
	}

	public void ClickAnswerButton(bool isCorrect)
	{
		if (isCorrect)
		{
			if (questionIDs.Count > 0)
			{
				StartCoroutine(Correct());
			}
			else
			{
				ShowCompletedResult();
			}
		}
		else
		{
			failCount++;
			if (failCount >= 3)
			{
				ShowFailedResult();
			}
			else
			{
				StartCoroutine(NotCorrect());
			}
		}
	}

	public void ClickBack()
	{
		SceneManager.LoadScene("Map");
	}

	
}
