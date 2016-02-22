using UnityEngine;
using System.Collections;

public class TakeIt : MonoBehaviour {

	public SimpleControl playerControl;
	public Animator playerAnimator;
	public Rigidbody2D playerRigidbody;
	public bool isOnArea = false;
	private bool isTaken = false;
	public MonoBehaviour[] afterTakenScripts;
	public Sprite[] elementSprites;
	private SpriteRenderer thisRenderer;
	private bool isGoToPosition = false;

	void Start()
	{
		thisRenderer = this.gameObject.GetComponent<SpriteRenderer>();
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0))
			isGoToPosition = true;
		if (isGoToPosition)
			playerControl.SetMovementSignAnimation ("Take");
		thisRenderer.sprite = elementSprites[1];
		if (isTaken == false && isOnArea)
		if (Input.GetMouseButtonDown(0) || isGoToPosition)
			TakeItOnPosition ();
	}

	void TakeItOnPosition() {
		playerControl.SetMovementSignState (false);
		isGoToPosition = false;
		playerControl.enabled = false;
		playerAnimator.Play("Take", -1, 0);
		playerRigidbody.velocity = new Vector2(0, 0);
		isTaken = true;
		foreach (MonoBehaviour script in afterTakenScripts)
		{
			script.enabled = true;
		}
		this.enabled = false;
	}

	void OnMouseExit()
	{
		thisRenderer.sprite = elementSprites[0];
		if (Input.GetMouseButtonDown (0))
			isGoToPosition = false;
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.name == "CharacterCentralPoint")
		{
			isOnArea = true;
			if (!isTaken && isGoToPosition)
				TakeItOnPosition ();
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.name == "CharacterCentralPoint")
		{
			isOnArea = false;
		}
	}
}
