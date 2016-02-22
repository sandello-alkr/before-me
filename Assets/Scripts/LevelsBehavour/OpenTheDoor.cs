using UnityEngine;
using System.Collections;

public class OpenTheDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("Door").GetComponent<Animator>().enabled = true;
        GameObject.Find("Door").GetComponent<Transform>().position = GameObject.Find("CharacterCentralPoint").transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Door").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            Application.LoadLevel("Final");
	}
}
