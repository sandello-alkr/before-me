using UnityEngine;
using System.Collections;

public class Fliper : MonoBehaviour {

    public bool isFacedRight = true;

    public void Flip()
    {
        isFacedRight = !isFacedRight;
        this.gameObject.transform.localScale = new Vector3(
            -this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y, 
            this.gameObject.transform.localScale.z);
    }
}
