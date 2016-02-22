using UnityEngine;
using System.Collections;

public class SetStandartFPS : MonoBehaviour {

	void Start () {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        this.enabled = false;
	}
}
