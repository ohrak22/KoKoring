using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class PlayScene : MonoBehaviour
{

	public MessageBox messageBox;
	public ResultPanel resultPanel;

	void Start()
	{
		GameController.Instance.messageBox = messageBox;
		GameController.Instance.resultPanel = resultPanel;

		GameController.Instance.RoundStart();
	}

	public void ClickBack()
	{
		SceneManager.LoadScene("Map");
	}
}
