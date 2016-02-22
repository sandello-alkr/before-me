using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public string levelName;
	void Start () {
		Application.LoadLevel (levelName);
	}
}
