using UnityEngine;
using System.Collections;

public class SetGameObjects : MonoBehaviour {

    public GameObject[] gameObjects;
    public GameObject[] killableGameObjects;

    void Update () {
        foreach (GameObject g in gameObjects)
            g.SetActive(true);
        foreach (GameObject g in killableGameObjects)
            g.SetActive(false);
        this.enabled = false;
	}
}
