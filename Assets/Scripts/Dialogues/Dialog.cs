using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dialog : MonoBehaviour {

    public string[] dialogues;
    public string[] animationNames;
    public Animator speakerAnimator;
    public MonoBehaviour[] nextScripts;
    private Text dialogueText;
    public int currentSpeachNumber;

    void Start()
    {
        this.Initiate();
        currentSpeachNumber = 0;
    }

    void Initiate()
    {
        GameObject.Find("CharacterCentralPoint").GetComponent<SimpleControl>().enabled = false;
        GameObject.Find("SpeachCanvas").GetComponent<Canvas>().enabled = true;
        GameObject.Find("DialogueText").GetComponent<Text>().text = dialogues[0].Replace("|n", "\n");
        GameObject.Find("NextStepButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("NextStepButton").GetComponent<Button>().onClick.AddListener(NextStep);
        if (speakerAnimator)
            speakerAnimator.Play(animationNames[currentSpeachNumber], -1, 0);
    }

    public void NextStep()
    {
        currentSpeachNumber++;
        if (currentSpeachNumber < dialogues.Length)
        {
            GameObject.Find("DialogueText").GetComponent<Text>().text = dialogues[currentSpeachNumber].Replace("|n", "\n");
        }
        else
        {
            currentSpeachNumber = 0;
            GameObject.Find("NextStepButton").GetComponent<Button>().onClick.RemoveAllListeners();
            GameObject.Find("SpeachCanvas").GetComponent<Canvas>().enabled = false;
            GameObject.Find("CharacterCentralPoint").GetComponent<SimpleControl>().enabled = true;
            foreach (MonoBehaviour script in nextScripts)
                script.enabled = true;
            speakerAnimator.Play("idle");
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update () {

	}
}
