using UnityEngine;
using System.Collections;

public class TakeItDesicions : MonoBehaviour
{

    public SimpleControl playerControl;
    public Animator playerAnimator;
    public Rigidbody2D playerRigidbody;
    public bool isOnArea = false;
    private bool isTaken = false;
    public MonoBehaviour[] afterTrueScripts;
    public MonoBehaviour[] afterFalseScripts;
    public Sprite[] elementSprites;
    private SpriteRenderer thisRenderer;
    public SettedState settedState;
	public MaxEnabler enabler;
	private bool isGoToPosition = false;

    void Start()
    {
        thisRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0))
			isGoToPosition = true;
        thisRenderer.sprite = elementSprites[1];
        if (isTaken == false && isOnArea)
        {
			if (Input.GetMouseButtonDown(0) || isGoToPosition)
            {
				isGoToPosition = false;
                playerControl.enabled = false;
                playerRigidbody.velocity = new Vector2(0, 0);
                if (settedState == null || !settedState.isSelected)
                {
                    foreach (MonoBehaviour script in afterFalseScripts)
                    {
                        script.enabled = true;
                    }
                } else
                {
                    foreach (MonoBehaviour script in afterTrueScripts)
                    {
                        script.enabled = true;
                    }
					elementSprites [1] = elementSprites [0];
                    if (enabler)
                        enabler.AddObject();
                    isTaken = true;
                }
                this.enabled = false;
            }
        }
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
