using UnityEngine;
using UnityEngine.UI;

public class SimpleChoiseBehaviour : MonoBehaviour {

	public Text choiseText;
	public string choiseQuestionString;
	public SetLightOn[] lightOnScripts;
	public SetLightOff[] lightOffScripts;
	public MonoBehaviour positiveBehaviour;
	public MonoBehaviour negativeBehaviour;

	void Start () {
		choiseText.text = choiseQuestionString;
	}

	public void PositiveAction() {
		ActionCommonPart ();
		positiveBehaviour.enabled = true;
	}

	public void NegativeAction() {
		ActionCommonPart ();
		negativeBehaviour.enabled = true;
	}

	public void ActionCommonPart() {
		foreach (SetLightOn lightOnScript in lightOnScripts)
			lightOnScript.enabled = false;
		foreach (SetLightOff lightOffScript in lightOffScripts)
			lightOffScript.enabled = true;
	}
}
