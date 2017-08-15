using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

public class MapScene : MonoBehaviour
{
	public UserInfoPanel userInfoPanel;

	void Start()
	{
		GameController.Instance.mapScene = this;

		UserData userData = GameDataManager.Instance.userData;

		userInfoPanel.SetUserData(userData);
	}

	public void SpanHeart()
	{
		userInfoPanel.SpanHeart();
	}

}
