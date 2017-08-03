using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnswerPanel : MonoBehaviour {

	public GameObject defaultButton;
	public Transform group;
	QuestionData questionData;

	void Start () {

		GameController.Instance.answerPanel = this;
	}

	public void Clear()
	{
		for (int i = group.childCount - 1; i >= 0; i--)
		{
			if (group.GetChild(i).name != "DefaultButton")
			{
				Destroy(group.GetChild(i).gameObject);
			}
		}
	}

	public void Setup(QuestionData data)
	{
		questionData = data;

		Clear();

		for (int i = 0; i < data.answers.Count; i++)
		{
			GameObject go = Instantiate(defaultButton);
			go.transform.SetParent(group);
			go.SetActive(true);
			go.transform.localScale = Vector3.one;
			go.transform.localPosition = Vector3.zero;

			AnswerButton btn = go.GetComponent<AnswerButton>();
			btn.Setup(data.answers[i]);
		}
	}
	
}
