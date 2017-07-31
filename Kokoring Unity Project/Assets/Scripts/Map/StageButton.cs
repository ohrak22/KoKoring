using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour {

	public int stageID;

	public void Click()
	{
		SceneManager.LoadScene("Play");
	}
}
