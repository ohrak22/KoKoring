using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class JellyMovement : MonoBehaviour {

	private bool isMoving = false;
	private Vector2 dirVector = Vector2.zero;
	private Vector2 pos;
	private Vector2 targetPos;


	public void Move(MoveDirection dir)
	{
		if (isMoving == false)
		{
			isMoving = true;
			pos = transform.position;

			if (dir == MoveDirection.Up)
			{
				dirVector = Vector2.up;
				targetPos = pos + new Vector2(0, 42);
			}
			else if (dir == MoveDirection.Down)
			{
				dirVector = Vector2.down;
				targetPos = pos + new Vector2(0, -42);
			}
			else if (dir == MoveDirection.Left)
			{
				dirVector = Vector2.left;
				targetPos = pos + new Vector2(-42, 0);
			}
			else if (dir == MoveDirection.Right)
			{
				dirVector = Vector2.right;
				targetPos = pos + new Vector2(42, 0);
			}

		}
	}

	void Update()
	{
		if (isMoving)
		{
			transform.position = Vector3.Lerp(transform.position, targetPos, 0.1f);

			if (Mathf.Abs(Vector2.Distance(transform.position, targetPos)) < 1f)
			{
				transform.position = targetPos;
				isMoving = false;
			}
		}
	}
}
