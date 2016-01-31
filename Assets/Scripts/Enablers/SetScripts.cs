using UnityEngine;
using System.Collections;

public class SetScripts : MonoBehaviour {

	public MonoBehaviour[] disabledScripts;

	void Start () {
		foreach (MonoBehaviour script in disabledScripts) {
			script.enabled = false;
		}
		this.enabled = false;
	}
}
