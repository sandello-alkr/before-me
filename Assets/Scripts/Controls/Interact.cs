using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

    public SimpleControl playerControl;
    public Animator playerAnimator;
    public Rigidbody2D playerRigidbody;
    public bool isOnArea = false;
    public MonoBehaviour[] afterTakenScripts;
    public Sprite[] elementSprites;
    public MonoBehaviour script;
    private SpriteRenderer thisRenderer;

    void Start()
    {
        thisRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void OnMouseOver()
    {
        thisRenderer.sprite = elementSprites[1];
        if (isOnArea)
        {
            isOnArea = true;
            if (Input.GetMouseButtonDown(0))
            {
                script.enabled = true;
            }
        }
    }

    void OnMouseExit()
    {
        thisRenderer.sprite = elementSprites[0];
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
