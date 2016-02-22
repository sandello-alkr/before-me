using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinalBehaviour : MonoBehaviour {
	public Image blackRenderer;
	public AudioSource cry;
	public AudioSource mainTheme;
	public float lastFrameTime;
	private bool isBegin = false;
	public Animator finalAnimator;

	void Start() {
		lastFrameTime = Time.time;
		finalAnimator.enabled = false;
		blackRenderer.color = new Color(blackRenderer.color.r, blackRenderer.color.g, blackRenderer.color.b, 1);
	}

	void Update() {
		if (lastFrameTime + 2 > Time.time) {
			mainTheme.volume -= 0.01f;
			return;
		}
		if (!isBegin) {
			finalAnimator.enabled = true;
			finalAnimator.Play ("Birth");
			mainTheme.volume = 0;
			cry.Play ();
			isBegin = true;
			return;
		} else {
			if (!cry.isPlaying && finalAnimator.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1) {
				Application.LoadLevel ("StartScreen");
				this.enabled = false;
			}
		}
	}
}
