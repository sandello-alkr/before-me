using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingLevelLoader : MonoBehaviour {

	void Start () {
		Application.LoadLevelAsync(PlayerPrefs.GetString("LevelName").ToString() != ""
			? PlayerPrefs.GetString("LevelName") : "StartScreen");
	}

	///
	///		Slow Method for slow pc
	///
	/*private AsyncOperation async;
	private string sceneName;
	private Text loadingText;

	 private void Start()
	 {
		sceneName = PlayerPrefs.GetString ("LevelName").ToString () != ""
			? PlayerPrefs.GetString ("LevelName") : "StartScreen";
		loadingText = GameObject.Find ("LoadingText").GetComponent<Text> ();
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
		if (async != null) {
			loadingText.text = string.Format ("Загрузка {0}%", async.progress * 100);
			if (async.progress >= 0.9f) {
				async.allowSceneActivation = true;
			}
		}
	 }*/
}
