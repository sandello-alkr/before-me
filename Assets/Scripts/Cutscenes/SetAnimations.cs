using UnityEngine;
using System.Collections;

public class SetAnimations : MonoBehaviour {

    public Animator[] animators;
    public string[] animationsName;
    public bool isWaitUntillPlay = false;
    public MonoBehaviour[] nextScripts;
    private bool isStarted = false;
    public int animatorId = 0;

	void Update () {
        if (!isStarted)
        {
            for (int i = 0; i < animators.Length; i++)
            {
                animators[i].Play(animationsName[i]);
            }
            isStarted = true;
            return;
        }
        if (isWaitUntillPlay)
        {
            if (isAnimationPlaying(animators[animatorId]))
                return;
        }
        foreach (MonoBehaviour script in nextScripts)
            script.enabled = true;
        isStarted = false;
        this.enabled = false;
	}

    bool isAnimationPlaying(Animator currentAnimator)
    {
        return currentAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }
}
