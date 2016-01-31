using UnityEngine;
using System.Collections;

public class DecideFate : MonoBehaviour {

	public string prefsName = "ReleaseFear";
	public int value = 0;
	public GameObject[] disablingGameObjects;
	public SetLightOff speachOffScript;
	public MonoBehaviour[] enablingGameScripts;

	void Start () {
		PlayerPrefs.SetInt (prefsName, value);
		foreach (GameObject gObject in disablingGameObjects) {
			gObject.SetActive (false);
		}
		speachOffScript.enabled = true;
		foreach (MonoBehaviour script in enablingGameScripts) {
			script.enabled = true;
		}
		this.gameObject.SetActive (false);
	}
}
