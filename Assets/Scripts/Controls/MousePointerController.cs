using UnityEngine;
using System.Collections;

public class MousePointerController : MonoBehaviour {

	private Texture2D defaultCursorTexture;
	public Texture2D activeCursorTexture;
	int cursorSizeX = 32;
	int cursorSizeY = 32;

	// Use this for initialization
	void Start () {
		Cursor.SetCursor (defaultCursorTexture, Vector2.zero, CursorMode.Auto);
	}
	
	// Update is called once per frame
	void Update () {


	}
}
