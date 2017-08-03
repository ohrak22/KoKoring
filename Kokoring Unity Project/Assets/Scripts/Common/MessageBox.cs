using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour {

	public Text messageText;
	public float duration;
	public CanvasGroup canvasGropu;
	
	public void Show(string message, float durationTime = 2f)
	{
		gameObject.SetActive(true);
		canvasGropu.alpha = 1;

		messageText.text = message;
		duration = durationTime;
	}

	public void Show(string message, Color color, float durationTime = 2f)
	{
		Show(message, durationTime);

		messageText.color = color;
	}

	public void Hide()
	{
		canvasGropu.alpha = 1;
		gameObject.SetActive(false);
	}

	void Update()
	{
		duration -= Time.deltaTime;

		if (duration < 0.5f)
		{
			canvasGropu.alpha = duration * 2f;
		}

		if (duration < 0)
		{
			gameObject.SetActive(false);
		}
	}

}
