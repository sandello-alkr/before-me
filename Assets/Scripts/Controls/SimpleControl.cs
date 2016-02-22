using UnityEngine;
using System.Collections;

public class SimpleControl : Fliper {

    public float speed;
    private Rigidbody2D playerRigidbody;
    private float currentXSpeed, currentYSpeed;
    private Vector2 positionToGo;
    public Animator playerAnimator;
    private string currentAnimation = "Idle";
    public string settedStateAnimation = "";
	public GameObject movementSign;
	private Animator movementSignAnimator;

	void Start () {
		movementSign.SetActive (false);
		movementSignAnimator = movementSign.GetComponent<Animator> ();
        playerRigidbody = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        Control();
        AnimateNavigation();
	}

	public void SetMovementSignAnimation(string name) {
		if (movementSignAnimator)
			movementSignAnimator.Play (name);
	}

	public void SetMovementSignState(bool state) {
		movementSign.SetActive (state);
	}
    void Control()
    {
        settedStateAnimation = "Flying";
        if (Input.GetMouseButton(0))
        {
            positionToGo = Input.mousePosition;
            positionToGo = Camera.main.ScreenToWorldPoint(positionToGo);
			movementSign.SetActive (true);
			movementSignAnimator.Play ("Blink");
			movementSign.transform.position = positionToGo;
        }
        currentXSpeed = this.transform.position.x < positionToGo.x ? speed : -speed;
        currentYSpeed = this.transform.position.y < positionToGo.y ? speed : -speed;
        if ((currentXSpeed > 0 && !isFacedRight) || (currentXSpeed < 0 && isFacedRight))
            Flip();
        if (IsSpeedSetted(this.transform.position.x, positionToGo.x, 0.1f))
            currentXSpeed = 0;
        if (IsSpeedSetted(this.transform.position.y, positionToGo.y, 0.1f)) 
            currentYSpeed = 0;
        if (currentXSpeed == 0 && currentYSpeed == 0)
		{
			movementSign.SetActive (false);
            settedStateAnimation = "Idle";
        }
        playerRigidbody.velocity = new Vector2(currentXSpeed, currentYSpeed);
    }

    bool IsSpeedSetted(float playerPosition, float positionToGo, float coefficient)
    {
        return Mathf.Abs(Mathf.Abs(playerPosition) - Mathf.Abs(positionToGo)) < coefficient;
    }

    void AnimateNavigation()
    {
        if (settedStateAnimation == "Flying" && currentAnimation == "Idle")
        {
            settedStateAnimation = "StartFlying";
            currentAnimation = "StartFlying";
            playerAnimator.Play(settedStateAnimation, -1, 0);
            return;
        } else
        {
            if (currentAnimation == "StartFlying")
            {
                if (isAnimationPlaying())
                {
                    return;
                } else
                {
                    settedStateAnimation = "Flying";
                    currentAnimation = "Flying";
                    playerAnimator.Play(settedStateAnimation, -1, 0);
                    return;
                }
            } else
            {
                if (currentAnimation == "Flying")
                {
                    if (settedStateAnimation == "Idle")
                    {
                        settedStateAnimation = "EndFlying";
                        currentAnimation = "EndFlying";
                        playerAnimator.Play(settedStateAnimation, -1, 0);
                        return;
                    }
                    else return;
                } else
                {
                    if (currentAnimation == "EndFlying" && !isAnimationPlaying())
                    {
                        settedStateAnimation = "Idle";
                        currentAnimation = "Idle";
                        playerAnimator.Play(settedStateAnimation, -1, 0);
                        return;
                    }
                }
            }
        }
    }

    bool isAnimationPlaying()
    {
        return playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }
}
