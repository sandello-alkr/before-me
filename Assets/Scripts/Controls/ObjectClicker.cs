using UnityEngine;
using System.Collections;

public class ObjectClicker : MonoBehaviour
{
    public MonoBehaviour nextScript;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            nextScript.enabled = true;
            this.enabled = false;
        }
    }
}
