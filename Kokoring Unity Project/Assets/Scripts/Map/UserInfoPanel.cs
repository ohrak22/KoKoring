using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UserInfoPanel : MonoBehaviour {

	public Text heartCountText;
	public Text diaCountText;
	public Text heartTimeText;

	private const int maxHeart = 5;
	private UserData userData;
	private float updateTime = 0f;
	private float heartTimer = 300f; // 5 * 60

	public void SpanHeart()
	{
		if (userData.heartCount > 1)
		{
			if (userData.heartCount == maxHeart)
			{
				heartTimer = 300f;
				heartTimeText.gameObject.SetActive(true);
				userData.countStartTime = DateTime.Now;
			}

			userData.heartCount--;
			GameDataManager.Instance.SaveUserData(userData);
		}
		else
		{
		}
	}

	public void SetUserData(UserData data)
	{
		userData = data;
		if (userData.heartCount < maxHeart)
		{
			TimeSpan timeSpan = DateTime.Now - data.countStartTime;
			userData.heartCount += (int)(timeSpan.TotalMinutes / 5);
			if (userData.heartCount > 5)
			{
				userData.heartCount = 5;
			}
			else
			{
				heartTimer = userData.heartUpdateRemain;
				heartTimeText.gameObject.SetActive(true);
			}
		}
		else
		{
			heartTimeText.gameObject.SetActive(false);
		}
	}
	
	public void SetHeartCount(int count)
	{
	}

	public void SetDiaCount(int count)
	{
		diaCountText.text = count.ToString();
	}

	void Update()
	{
		updateTime -= Time.deltaTime;
		if (updateTime <= 0f && heartTimer > 0f)
		{
			updateTime = 1f;
			heartTimer -= 1f;

			if (heartTimer < 0)
			{
				userData.heartCount++;
				if (userData.heartCount < 5)
				{
					heartTimer = 300f;
				}
			}

			int min = (int)(heartTimer / 60f);
			int sec = (int)(heartTimer % 60f);
			heartCountText.text = userData.heartCount + "/" + maxHeart;
			heartTimeText.text = min + ":" + sec;
		}
	}
}
