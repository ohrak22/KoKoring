using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;

[System.Serializable]
public class StageLevelData
{
	public string stageName;
	public int id;
	public int starCount;
	public bool isClear;
	public bool currentStage;

}
