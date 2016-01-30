using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour {

    public AudioClip audio;
    public AudioSource source;
    public SimpleControl playerControl;
    public Animator playerAnimator;
    public Rigidbody2D playerRigidbody;
    public bool isOnArea = false;
    public MonoBehaviour[] afterTakenScripts;
    public Sprite[] elementSprites;
    private SpriteRenderer thisRenderer;

    void Start()
    {
        thisRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void OnMouseOver()
    {
        thisRenderer.sprite = elementSprites[1];
        if (!source.isPlaying && isOnArea)
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerAnimator.Play("Take", -1, 0);
                playerRigidbody.velocity = new Vector2(0, 0);
                source.PlayOneShot(audio);
                foreach (MonoBehaviour script in afterTakenScripts)
                {
                    script.enabled = true;
                }
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
