using UnityEngine;
using System.Collections;

public class StretchToFullScreen : MonoBehaviour {

	void Start () {
        var sr = this.gameObject.GetComponent<SpriteRenderer>();
        if (sr == null) return;

        transform.localScale = new Vector3(1, 1, 1);

        var width = sr.sprite.bounds.size.x;
        var height = sr.sprite.bounds.size.y;

        var worldScreenHeight = Camera.main.orthographicSize * 2.0;
        var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        this.gameObject.transform.localScale = new Vector3((float)(worldScreenWidth / width), (float)(worldScreenHeight / height), 
            this.gameObject.transform.localScale.z);
        this.enabled = false;
    }
}
