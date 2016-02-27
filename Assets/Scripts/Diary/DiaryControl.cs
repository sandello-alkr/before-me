using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

public class DiaryControl : MonoBehaviour
{

    public static DiaryControl control;

    public Text textObject;

    private List<string> entries;

    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
            entries = new List<string>();
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        textObject = textObject.GetComponent<Text>();
    }

    public void addEntry(string key)
    {
        entries.Add(TextStorage.control.getEntryByKey(key));
        refreshUIText();
    }

    protected void refreshUIText()
    {
        textObject.text = "";
        foreach (string textEntry in entries)
        {
            textObject.text += textEntry;
            textObject.text += "\n\n";
        }
    }
}