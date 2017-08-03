using UnityEditor;
using UnityEngine;
using System.Collections;

public class GameDataWindow : EditorWindow {

	[MenuItem("Window/Game Data Window")]
	static void Init()
	{
		// Get existing open window or if none, make a new one:
		GameDataWindow window = (GameDataWindow)EditorWindow.GetWindow(typeof(GameDataWindow));
		window.Show();
	}

	void OnGUI()
	{
	}
}
