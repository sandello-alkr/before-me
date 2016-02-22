using UnityEngine;
using System.Collections;

public class MaxEnabler : MonoBehaviour {

    public int maxObjectsCount = 2;
    public int currentObjectsCount = 0;
    public MonoBehaviour endBehaviour;

    public void AddObject()
    {
        currentObjectsCount++;
        if (currentObjectsCount >= maxObjectsCount)
        {
            if (endBehaviour)
                endBehaviour.enabled = true;
        }
        this.enabled = false;
    }
}
