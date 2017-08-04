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
		questionData = data;
		if (data.type == QuestionData.QuestionType.Translate)
		{
			questionText.text = "Translate this sentence.";
		}

		sentenceText.text = data.sentence;
	}
	
}
