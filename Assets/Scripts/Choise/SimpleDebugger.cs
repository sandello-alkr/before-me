using UnityEngine;
using System.Collections;

public class SimpleDebugger : MonoBehaviour {

	public string actionString;

	void Start () {
		Debug.Log (actionString);	
	}
}
