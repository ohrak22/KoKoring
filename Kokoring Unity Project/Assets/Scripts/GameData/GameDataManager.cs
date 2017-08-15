using UnityEngine;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using System.Text;

public class GameDataManager {

	private static GameDataManager instance;
	public static GameDataManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameDataManager();
				instance.LoadAll();
			}

			return instance;
		}
	}

	//public QuestionDataTable questionTable = new QuestionDataTable();
	public QuestionLevelDataTable questionLevelTable = new QuestionLevelDataTable();

	public UserData userData = new UserData();

	public void LoadAll()
	{
		//questionTable.Load();
		questionLevelTable.Load();

		LoadUserData();
	}

	public void SaveUserData(UserData data)
	{
		userData = data;
		SaveUserData();
	}

	public void SaveUserData()
	{
		string path = Application.streamingAssetsPath + "/UserData.json";

		if (Application.platform == RuntimePlatform.Android)
		{
			path = Application.persistentDataPath + "/UserData.json";
		}

		using (FileStream fs = new FileStream(path, FileMode.Create))
		{
			using (StreamWriter writer = new StreamWriter(fs))
			{
				string json = JsonConvert.SerializeObject(userData);
				writer.Write(json);
			}
		}
	}

	public void LoadUserData()
	{
		string path = Application.streamingAssetsPath + "/UserData.json";

		if (Application.platform == RuntimePlatform.Android)
		{
			path = Application.persistentDataPath + "/UserData.json";
		}

		using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
		{
			using (StreamReader reader = new StreamReader(fs, Encoding.Default))
			{
				string json = "";
				while (!reader.EndOfStream)
				{
					json += reader.ReadLine() + "\n";
				}

				if (json.Length == 0)
				{
					CreateNewAccount(fs, path);
				}
				else
				{
					userData = JsonConvert.DeserializeObject<UserData>(json);
				}
			}
		}
	}

	public void CreateNewAccount(FileStream fs, string path)
	{
		userData = new UserData();
		userData.currentStage = 1;
		userData.diaCount = 0;
		userData.exp = 0;
		userData.level = 1;
		userData.heartCount = 5;
		userData.userName = "Player001";

		string json = JsonConvert.SerializeObject(userData);

		using (StreamWriter writer = new StreamWriter(fs))
		{
			writer.Write(json);
		}
#if UNITY_EDITOR
		UnityEditor.AssetDatabase.Refresh();
#endif
	}

}
