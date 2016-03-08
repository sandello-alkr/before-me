using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public string levelName;
	public bool isNeedRestart = false;
	void Start () {
		if (!isNeedRestart)
			PlayerPrefs.SetString ("LevelName", levelName);
		else
			PlayerPrefs.SetString ("LevelName", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
		Application.LoadLevel("LoadingScreen");
	}
}
