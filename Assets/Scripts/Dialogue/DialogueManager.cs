using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public static bool isDialogueRunning;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    [SerializeField] private TextScroller textScroller;
    [SerializeField] private Canvas dialogueCanvas;

    public static event OnDialogueFinished onDialogueFinished;
    public delegate void OnDialogueFinished();

    private void Start()
    {
        dialogueCanvas.gameObject.SetActive(false);
    }

    public void StartDialogue(DialogueObject dialogue)
    {
        if (isDialogueRunning)
        {
            //Debug.LogWarning("Dialogue is already running, but is trying to be started once more. Ignoring...");
            return;
        }
        isDialogueRunning = true;
        dialogueCanvas.gameObject.SetActive(true);
        textScroller.StartDialogue(dialogue);
    }
    public void ContinueDialogue()
    {
        if (!textScroller.Continue())
        {
            isDialogueRunning = false;
            dialogueCanvas.gameObject.SetActive(false);
            onDialogueFinished?.Invoke();
        }
    }
}
