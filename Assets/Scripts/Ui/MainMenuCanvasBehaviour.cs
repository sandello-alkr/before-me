using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenuCanvasBehaviour : MonoBehaviour {

	public Canvas[] anotherCanvases;
	//Состояния канвасов на момент нажатия эскейпа. Необходимо для их восстановления
	public List<bool> anotherCanvasesStates;	
	private bool isEnabled = false;
	private Canvas selfCanvas;
	public SimpleControl control;
	private bool controlState;

	void Start () {
		selfCanvas = this.gameObject.GetComponent<Canvas> ();
		foreach (Canvas canvas in anotherCanvases) {
			anotherCanvasesStates.Add (false);
		}
		selfCanvas.enabled = false;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			isEnabled = !isEnabled;
			if (isEnabled)
				EnableCanvasBehaviour ();
			else
				DisableCanvasBehaviour ();
		}
	}

	void EnableCanvasBehaviour() {
		for (int i = 0; i < anotherCanvases.Length; i++) {
			anotherCanvasesStates [i] = anotherCanvases [i].enabled;
			anotherCanvases [i].enabled = false;
		}
		controlState = control.enabled;
		control.enabled = false;
		GameObject.Find ("CharacterCentralPoint").GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		selfCanvas.enabled = true;
	}

	public void DisableCanvasBehaviour() {
		for (int i = 0; i < anotherCanvases.Length; i++)
			anotherCanvases [i].enabled = anotherCanvasesStates [i];
		selfCanvas.enabled = false;
		if (!control.enabled)
			control.enabled = controlState;
	}
}
