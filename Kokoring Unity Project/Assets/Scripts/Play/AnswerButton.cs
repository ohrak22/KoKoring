using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour {

	public Text answerText;

	private AnswerData answerData;
	
	public void Setup(AnswerData data)
	{
		answerData = data;
		answerText.text = answerData.answer;
	}
	
	public void Click()
	{
		GameController.Instance.ClickAnswerButton(answerData.isCorrect);
	}
}
