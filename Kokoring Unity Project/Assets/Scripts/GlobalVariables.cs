using UnityEngine;
using System.Collections;

public enum MapEntryStatus
{
	StageClear,
	StageFailed,

}

public class GlobalVeriables
{
	public static int curStageID = 1;
	public static MapEntryStatus mapStatus = MapEntryStatus.StageFailed;
}
