using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
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
        dialogueCanvas.gameObject.SetActive(true);
        textScroller.StartDialogue(dialogue);
    }
    public void ContinueDialogue()
    {
        if (!textScroller.Continue())
        {
            dialogueCanvas.gameObject.SetActive(false);
            onDialogueFinished?.Invoke();
        }
    }
}
