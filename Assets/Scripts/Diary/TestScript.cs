using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

    void OnGUI()
    {
        if (GUI.Button(new Rect(10,200,100,30), "addEntry"))
        {
            DiaryControl.control.addEntry("#diaryText1");
        }
    }
}
