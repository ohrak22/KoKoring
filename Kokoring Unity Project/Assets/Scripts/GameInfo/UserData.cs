using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

public class UserStageData
{
	public int stageKey;
	public int starCount;
}

public class UserData {

	public string userName;
	public int level;
	public int exp;
	public int heartCount;
	public int diaCount;

	public int currentStage = 1;
	public Dictionary<int, UserStageData> clearStageDic = new Dictionary<int, UserStageData>();


}


