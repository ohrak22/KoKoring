using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class JellyBase : MonoBehaviour {

	public Text number;
	public JellyMovement movement;

	public void Init(JellyData data, int row, int col)
	{
		gameObject.SetActive(true);
		number.text = data.id.ToString();
		Vector2 pos = new Vector2(-168, 168);
		pos.x += (col * 42);
		pos.y -= (row * 42);
		transform.localPosition = pos;
		transform.localScale = Vector3.one;

	}

	public void OnPointerDown(BaseEventData eventData)
	{
	}

	public void OnPointerUp(BaseEventData eventData)
	{
	}

	public void OnDrag(BaseEventData eventData)
	{
		PointerEventData pointerData = eventData as PointerEventData;

		if(pointerData.delta.magnitude > 10)
		{
			if (Mathf.Abs(pointerData.delta.x) > Mathf.Abs(pointerData.delta.y))
			{
				if (pointerData.delta.x > 0)
				{
					movement.Move(MoveDirection.Right);
				}
				else if (pointerData.delta.x < 0)
				{
					movement.Move(MoveDirection.Left);
				}
			}
			else
			{
				if (pointerData.delta.y > 0)
				{
					movement.Move(MoveDirection.Up);
				}
				else if (pointerData.delta.y < 0)
				{
					movement.Move(MoveDirection.Down);
				}
			}
		}



	}

	
}
