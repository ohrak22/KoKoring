using UnityEngine;
using System.Collections;

public class GameController {

	private static GameController instance;
	public static GameController Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameController();
			}

			return instance;
		}
	}

	public int roundIndex = 0;
	QuestionLevelData levelData;
	public int failCount = 0;

	public QuestionPanel questionPanel;
	public AnswerPanel answerPanel;
	public MessageBox messageBox;
	public ResultPanel resultPanel;

	public void RoundStart()
	{
		roundIndex = 0;
		failCount = 0;
		levelData = GameDataManager.Instance.questionLevelTable[GlobalVeriables.curStageID];
		SetupQuestion(levelData.questionIDList[roundIndex]);
		roundIndex++;
	}

	public void NextRound()
	{
		if (levelData.questionIDList.Count > roundIndex)
		{
			SetupQuestion(levelData.questionIDList[roundIndex]);
			roundIndex++;
		}
		else
		{
			roundIndex = 0;
			ResultData data = new ResultData();
			data.titleText = "Level " + GlobalVeriables.curStageID;
			data.contextText = "Level Completed!";
			data.buttonText = "Continue";
			data.starCount = 3 - failCount;
			Clear();
			ShowResult(data);
		}
	}

	public void ShowResult(ResultData data)
	{
		resultPanel.Show(data);
	}

	public void SetupQuestion(int questionID)
	{
		QuestionData questionData = GameDataManager.Instance.questionTable[questionID];
		questionPanel.Setup(questionData);
		answerPanel.Setup(questionData);
	}

	public void Clear()
	{
		messageBox.Hide();
		questionPanel.Clear();
		answerPanel.Clear();
	}

	public void ClickAnswerButton(bool isCorrect)
	{
		if (isCorrect)
		{
			NextRound();
		}
		else
		{
			failCount++;
			if (failCount > 3)
			{
				ResultData data = new ResultData();
				data.titleText = "Level " + GlobalVeriables.curStageID;
				data.contextText = "Level Failed!";
				data.buttonText = "Try Again";
				data.starCount = 0;
				Clear();
				ShowResult(data);
			}
			else
			{
				ShowMessageBox("It is not the correct answer.");
			}

		}
	}

	public void ShowMessageBox(string message)
	{
		messageBox.Show(message, Color.red);
	}
}
