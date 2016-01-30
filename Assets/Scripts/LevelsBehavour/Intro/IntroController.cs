using UnityEngine;
using System.Collections;

public class IntroController : MonoBehaviour {

    public float speed;
    private int step = 0;
    private Animator logoAnimator;
    private GameObject logo;
    private Rigidbody2D logoRigidbody;
    private float currentXSpeed, currentYSpeed;
    private Vector2 positionToGo;
    private float lastFrameTime;
    public SetLightOn nextScript;
    public float extremumYPosition;

    void Start()
    {
        logo = GameObject.Find("Logo");
        logoRigidbody = logo.GetComponent<Rigidbody2D>();
        logoAnimator = logo.GetComponent<Animator>();
        lastFrameTime = Time.time;
    }

    void Update()
    {
        if (step == 0)
        {
            logoAnimator.Play("Spark");
            step++;
            return;
        }
        if (step == 1)
        {
            if (logoAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                step++;
                Application.LoadLevel("Level1");
                Debug.Log("Loaded");
                return;
            } else
                FollowMouse();
        }
    }

    void FollowMouse()
    {
        positionToGo = Input.mousePosition;
        positionToGo = Camera.main.ScreenToWorldPoint(positionToGo);
        currentXSpeed = this.transform.position.x<positionToGo.x? speed : -speed;
        currentYSpeed = this.transform.position.y<positionToGo.y? speed : -speed;
        if (IsSpeedSetted(this.transform.position.x, positionToGo.x, 0.1f))
            currentXSpeed = 0;
        if (IsSpeedSetted(this.transform.position.y, positionToGo.y, 0.1f))
            currentYSpeed = 0;
        logoRigidbody.velocity = new Vector2(currentXSpeed, currentYSpeed);
    }

    bool IsSpeedSetted(float playerPosition, float positionToGo, float coefficient)
    {
        return Mathf.Abs(Mathf.Abs(playerPosition) - Mathf.Abs(positionToGo)) < coefficient;
    }

}
