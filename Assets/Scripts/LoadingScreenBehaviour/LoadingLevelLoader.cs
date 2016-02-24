using UnityEngine;
using System.Collections;

public class LoadingLevelLoader : MonoBehaviour {

	void Start () {
		Application.LoadLevelAsync(PlayerPrefs.GetString("LevelName").ToString() != ""
			? PlayerPrefs.GetString("LevelName") : "StartScreen");
	}

	///
	///		Slow Method for slow pc
	///
	/*
	private AsyncOperation async;
	private string sceneName;

	 private void Start()
	 {
		sceneName = PlayerPrefs.GetString ("LevelName").ToString () != ""
			? PlayerPrefs.GetString ("LevelName") : "StartScreen";
		 StartCoroutine(LoadScene());
	 }

	 IEnumerator LoadScene()
	 {
		 async = Application.LoadLevelAsync(sceneName);
		 async.allowSceneActivation = false;
		 yield return async;
	 }

	///
	///  When allowSceneActivateon equals false, loading stucked on 0.9 of progress
	///
	 private void Update()
	{
		if (async != null && async.progress >= 0.9f) {
			async.allowSceneActivation = true;
		}
	 }
	*/
}
