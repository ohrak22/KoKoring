using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeartPanel : MonoBehaviour {

	public List<Animation> heartList;
	public int index = 0;

	public void Init()
	{
		for (int i = 0; i < heartList.Count; i++)
		{
			heartList[i].gameObject.SetActive(true);
		}
		index = 0;
	}

	public void DecreaseHeart()
	{
		if (heartList.Count > index)
		{
			heartList[index].Play();
			index++;
		}
	}
}
