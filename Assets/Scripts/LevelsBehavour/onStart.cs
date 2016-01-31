using UnityEngine;
using System.Collections;

public class onStart : MonoBehaviour {

    public MonoBehaviour[] nextScripts;

    // Use this for initialization
    void Start () {
        foreach (MonoBehaviour script in nextScripts)
            script.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
