using UnityEngine;
using UnityEngine.UI;

public class SimpleDialogue : MonoBehaviour {
    public int currentSpeachNumber;
    public GameObject dialogueCanvas;
    public string[] dialogues;
    public string[] animationNames;
    public Animator speakerAnimator;
    public bool hideOnStart;
    private bool isNeedInitiate;
    private Text dialogueText;
    public MonoBehaviour[] nextScripts;
    public bool isForceDisableControl = false;
	private bool isColorSetted = false;

    void Start()
    {
        if (!hideOnStart)
            Initiate();
        
    }

    void Initiate()
    {
		isNeedInitiate = true;
		if (dialogueCanvas.active == true)
			return;
		if (isForceDisableControl) {
			GameObject.Find ("CharacterCentralPoint").GetComponent<SimpleControl> ().enabled = false;
		}
        dialogueCanvas.SetActive(true);
        dialogueText = GameObject.Find("DialogueText").GetComponent<Text>();
        currentSpeachNumber = 0;
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
		if (isNeedInitiate) {
			Initiate ();
		}
		if (Input.GetMouseButtonDown(1))
			SetNextStep();
    }
}
