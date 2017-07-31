using UnityEngine;
using System.Collections;
using Newtonsoft.Json;

public class PlayScene : MonoBehaviour {

	public GameObject defaultJelly;
	public Transform box;

	void Start () {
		
		int[,] levelArr = GameDataManager.Instance.levelData.data;

		for (int row = 0; row < levelArr.GetLength(0); row++)
		{
			for (int col = 0; col < levelArr.GetLength(1); col++)
			{
				JellyData jellyData = GameDataManager.Instance.jellyTable.data[levelArr[row, col]];

				GameObject go = Instantiate(defaultJelly);
				go.transform.SetParent(box);
				JellyBase jelly = go.GetComponent<JellyBase>();
				jelly.Init(jellyData, row, col);
			}
		}
	}
	
}
