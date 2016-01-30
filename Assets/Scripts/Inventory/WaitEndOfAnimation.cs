using UnityEngine;
using System.Collections;

public class WaitEndOfAnimation : MonoBehaviour {

    public Animator waitedAnimator;
    public MonoBehaviour[] scripts;

	void Update () {
	    if (waitedAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            foreach (MonoBehaviour script in scripts)
                script.enabled = true;
            waitedAnimator.Play("Idle");
            this.enabled = false;
        }
	}
}
