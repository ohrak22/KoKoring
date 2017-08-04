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

	public PlayScene playScene;

	public void ClickAnswerButton(bool isCorrect)
	{
		playScene.ClickAnswerButton(isCorrect);
	}








}
