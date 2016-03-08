using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetLightOff : MonoBehaviour {

    public MonoBehaviour nextScript;
    public SpriteRenderer gameObjectRenderer;
    public Image imageRenderer;
	public Text textRenderer;
    public float spriteShutSpeed = -0.02f;
    private float lastFrameTime = 0;
    public float frameSpeed = 0.04f;

    void Start()
    {
        lastFrameTime = Time.time;
    }
	
	public void Update () {
        if (lastFrameTime + frameSpeed < Time.time)
        {
            lastFrameTime = Time.time;
            if (!ColorOption())
            {
                if (nextScript)
                    nextScript.enabled = true;
                this.enabled = false;
            }
        }
	}

    public virtual bool ColorOption()
    {
        if (gameObjectRenderer)
        {
            if (gameObjectRenderer.color.a > 0)
            {
                ChangeColor();
                return true;
            }
        } else
        {
			if (textRenderer) {
				if (textRenderer.color.a > 0) {
					ChangeColor ();
					return true;
				}
			} else {
				if (imageRenderer.color.a > 0) {
					ChangeColor ();
					return true;
				}
			}
        }
        return false;
    }

    protected void ChangeColor()
    {
        if (gameObjectRenderer)
            gameObjectRenderer.color = new Color(gameObjectRenderer.color.r, gameObjectRenderer.color.g,
                gameObjectRenderer.color.b, gameObjectRenderer.color.a + spriteShutSpeed);
        if (imageRenderer)
            imageRenderer.color = new Color(imageRenderer.color.r, imageRenderer.color.g,
                imageRenderer.color.b, imageRenderer.color.a + spriteShutSpeed);
		if (textRenderer)
			textRenderer.color = new Color(textRenderer.color.r, textRenderer.color.g,
				textRenderer.color.b, textRenderer.color.a + spriteShutSpeed);
    }
}
