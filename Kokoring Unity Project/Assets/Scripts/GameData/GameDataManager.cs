using UnityEngine;
using System.Collections;

public class GameDataManager {

	private static GameDataManager instance;
	public static GameDataManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameDataManager();
			}

			instance.LoadAll();

			return instance;
		}
	}

	public QuestionDataTable questionTable = new QuestionDataTable();
	public QuestionLevelDataTable questionLevelTable = new QuestionLevelDataTable();

	public void LoadAll()
	{
		questionTable.Load();
		questionLevelTable.Load();
	}

}
