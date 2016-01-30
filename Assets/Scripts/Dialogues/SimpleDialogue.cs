using UnityEngine;
using UnityEngine.UI;

public class SimpleDialogue : MonoBehaviour {
    public int currentSpeachNumber;
    public GameObject dialogueCanvas;
    public string[] dialogues;
    public string[] animationNames;
    public Animator speakerAnimator;
    private bool isNeedInitiate;
    private Text dialogueText;
    private Button nextStepButton;
    public MonoBehaviour[] nextScripts;

    void Start()
    {
        Initiate();
    }

    void Initiate()
    {
        dialogueCanvas.SetActive(true);
        dialogueText = GameObject.Find("DialogueText").GetComponent<Text>();
        nextStepButton = GameObject.Find("NextStepButton").GetComponent<Button>();
        currentSpeachNumber = 0;
        nextStepButton.onClick.AddListener(() => SetNextStep());
        dialogueText.text = dialogues[0].Replace("|n", "\n");
        isNeedInitiate = false;
    }

    public void SetNextStep()
    {
        currentSpeachNumber++;
        if (currentSpeachNumber >= dialogues.Length)
        {
            isNeedInitiate = true;
            dialogueCanvas.SetActive(false);
            nextStepButton.onClick.RemoveAllListeners();
            foreach (MonoBehaviour script in nextScripts)
                script.enabled = true;
            this.enabled = false;
            return;
        }
        dialogueText.text = dialogues[currentSpeachNumber].Replace("|n", "\n");
        if (speakerAnimator)
            speakerAnimator.Play(animationNames[currentSpeachNumber], -1, 0);
    }

    void Update()
    {
        if (isNeedInitiate)
            Initiate();
    }
}
