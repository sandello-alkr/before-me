using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettedState : MonoBehaviour {

    public bool isSelected = false;
    public Sprite[] sprites;
    public SettedState[] states;

    public void SetState()
    {
		GameObject.Find ("CharacterCentralPoint").GetComponent<SimpleControl> ().Stop();
        isSelected = !isSelected;
        foreach (SettedState state in states)
        {
            state.GetComponent<Image>().sprite = state.sprites[0];
            state.isSelected = false;
        }
        if (!isSelected)
            this.gameObject.GetComponent<Image>().sprite = sprites[0];
        else
            this.gameObject.GetComponent<Image>().sprite = sprites[1];
    }
}
