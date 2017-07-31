using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MapScene : MonoBehaviour {

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
	
	}

	public void ClickPlay()
	{
		SceneManager.LoadScene("Play");
	}
}
