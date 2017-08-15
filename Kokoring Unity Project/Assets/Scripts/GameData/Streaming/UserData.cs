using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System;

public class UserStageData
{
	public int stageKey;
	public int starCount;
}

public class UserData
{
	public string userName;
	public int level;
	public int exp;
	public int heartCount;
	public DateTime countStartTime = new DateTime();
	public float heartUpdateRemain;

	public int diaCount;

	public int currentStage = 1;
	public Dictionary<int, UserStageData> clearStageDic = new Dictionary<int, UserStageData>();
}


