using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueFromClick : MonoBehaviour {

    public bool isOnArea = false;
    public MonoBehaviour[] afterTakenScripts;
    public Sprite[] elementSprites;

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
                this.Initiate();
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
        GameObject.Find("CharacterCentralPoint").GetComponent<SimpleControl>().enabled = false;
        GameObject.Find("SpeachCanvas").GetComponent<Canvas>().enabled = true;
        GameObject.Find("DialogueText").GetComponent<Text>().text = dialogues[0].Replace("|n", "\n");
        GameObject.Find("NextStepButton").GetComponent<Button>().onClick.AddListener(NextStep);
    }

    public void NextStep()
    {
        currentSpeachNumber++;
        if (currentSpeachNumber < dialogues.Length)
        {
            GameObject.Find("DialogueText").GetComponent<Text>().text = dialogues[currentSpeachNumber].Replace("|n", "\n");
        } else
        {
            currentSpeachNumber = 0;
            GameObject.Find("NextStepButton").GetComponent<Button>().onClick.RemoveAllListeners();
            GameObject.Find("SpeachCanvas").GetComponent<Canvas>().enabled = false;
            GameObject.Find("CharacterCentralPoint").GetComponent<SimpleControl>().enabled = true;
            foreach (MonoBehaviour script in nextScripts)
                script.enabled = true;
        }
    }

    void Update()
    {
    }
}
