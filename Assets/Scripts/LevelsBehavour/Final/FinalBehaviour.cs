using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinalBehaviour : MonoBehaviour {
	public Image blackRenderer;
	public AudioSource cry;
	public AudioSource mainTheme;
	public float lastFrameTime;
	private bool isBegin = false;

	void Start() {
		lastFrameTime = Time.time;
		blackRenderer.color = new Color(blackRenderer.color.r, blackRenderer.color.g, blackRenderer.color.b, 1);
	}

	void Update() {
		if (lastFrameTime + 2 > Time.time) {
			mainTheme.volume -= 0.01f;
			return;
		}
		if (!isBegin) {
			mainTheme.volume = 0;
			cry.Play ();
			isBegin = true;
			return;
		} else {
			if (!cry.isPlaying) {
				Application.LoadLevel ("MainScreen");
				this.enabled = false;
			}
		}
	}
}
