using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionPanel : MonoBehaviour {

	public Text questionText;
	public Text sentenceText;
	public Text answerText;
	QuestionData questionData;

	void Start () {

	}

	public void Clear()
	{
		questionText.text = "";
		sentenceText.text = "";
		answerText.text = "";
	}

	public void Setup(QuestionData data)
	{
		answerText.text = "";
		questionData = data;
		questionText.text = data.question;
		sentenceText.text = data.sentence;
	}

	public void SetAnswerText(string text, bool correct)
	{
		answerText.text = text;
		if (correct)
			answerText.color = Color.black;
		else
			answerText.color = Color.red;

	}

}
