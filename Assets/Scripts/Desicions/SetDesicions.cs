using UnityEngine;
using System.Collections;

public class SetDesicions : MonoBehaviour {

	void Start () {
        PlayerPrefs.SetInt("ReleaseFear", 0);
        this.enabled = false;
	}
}
