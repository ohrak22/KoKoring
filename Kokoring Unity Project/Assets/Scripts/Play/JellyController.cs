using UnityEngine;
using System.Collections;

public class JellyController {

	private static JellyController instance;

	public static JellyController Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new JellyController();
			}

			return instance;
		}
	}
}
