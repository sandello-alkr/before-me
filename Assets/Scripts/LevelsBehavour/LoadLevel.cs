using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public string levelName;
	void Start () {
		PlayerPrefs.SetString ("LevelName", levelName);
		Application.LoadLevel("LoadingScreen");
	}
}
