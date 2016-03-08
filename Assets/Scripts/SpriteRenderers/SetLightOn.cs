using UnityEngine;
using System.Collections;

public class SetLightOn : SetLightOff
{
    public override bool ColorOption()
    {
        if (gameObjectRenderer)
        {
            if (gameObjectRenderer.color.a < 1)
            {
                ChangeColor();
                return true;
            }
        }
        else
        {
			if (textRenderer) {
				if (textRenderer.color.a < 1) {
					ChangeColor ();
					return true;
				}
			} else {
				if (imageRenderer.color.a < 1) {
					ChangeColor ();
					return true;
				}
			}
        }
        return false;
    }
}
