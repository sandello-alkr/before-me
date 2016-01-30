using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueFromClick : MonoBehaviour {

    public SimpleControl playerControl;
    public Animator playerAnimator;
    public Rigidbody2D playerRigidbody;
    public bool isOnArea = false;
    public MonoBehaviour[] afterTakenScripts;
    public Sprite[] elementSprites;

    public GameObject dialogueCanvas;
    public string[] dialogues;
    public string[] animationNames;
    public Animator speakerAnimator;
    public MonoBehaviour[] nextScripts;

    private SpriteRenderer thisRenderer;
    private bool isNeedInitiate;
    private Text dialogueText;
    private Button nextStepButton;
    private int currentSpeachNumber;

    void Start()
    {
        thisRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void OnMouseOver()
    {
        thisRenderer.sprite = elementSprites[1];
        if (isOnArea)
        {
            isOnArea = true;
            if (Input.GetMouseButtonDown(0))
            {
                this.isNeedInitiate = true;
                this.Update();
            }
        }
    }

    void OnMouseExit()
    {
        thisRenderer.sprite = elementSprites[0];
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "CharacterCentralPoint")
        {
            isOnArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "CharacterCentralPoint")
        {
            isOnArea = false;
        }
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
            //isNeedInitiate = true;
            dialogueCanvas.SetActive(false);
            nextStepButton.onClick.RemoveAllListeners();
            foreach (MonoBehaviour script in nextScripts)
                script.enabled = true;
            //this.enabled = false;
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
