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

	public LevelData levelData = new LevelData();
	public JellyDataTable jellyTable = new JellyDataTable();

	public void LoadAll()
	{
		levelData.Load();
		jellyTable.Load();
	}

}
