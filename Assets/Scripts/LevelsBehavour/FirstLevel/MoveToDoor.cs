using UnityEngine;
using System.Collections;

public class MoveToDoor : MonoBehaviour {

	public Vector2 positionToGo;
	public Vector2 speed = new Vector2();
	public SetLightOff lightOffPlayer;
	private float lastFrameTime = 0;
	private SimpleControl simpleControl;
	private float xSpeed;
	private float ySpeed;
	private GameObject playerPoint;

	void Start() {
		lastFrameTime = Time.time;
		playerPoint = GameObject.Find ("CharacterCentralPoint");
		GameObject.Find ("Player").GetComponent<Animator> ().Play ("Fly");
		simpleControl = GameObject.Find ("CharacterCentralPoint").GetComponent<SimpleControl> ();
		if (!simpleControl.isFacedRight)
			simpleControl.Flip ();
	}

	void Update () {
		if (Time.time < lastFrameTime + 0.04)
			return;
		lastFrameTime = Time.time;
		xSpeed = 0;
		ySpeed = 0;
		if (playerPoint.transform.position.x < positionToGo.x)
			xSpeed = speed.x;
		if (playerPoint.transform.position.y < positionToGo.y)
			ySpeed = speed.y;
		if (xSpeed == 0 && ySpeed == 0) {
			lightOffPlayer.enabled = true;
			this.enabled = false;
			return;
		}
		playerPoint.transform.position = new Vector3 (playerPoint.transform.position.x + xSpeed,
			playerPoint.transform.position.y + ySpeed, playerPoint.transform.position.z);
	}
}
