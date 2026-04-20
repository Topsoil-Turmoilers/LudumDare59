using UnityEngine;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour
{
    [SerializeField] private DialogueObject prologueDialog;

    private void Start()
    {
        DialogueManager.instance.StartDialogue(prologueDialog);

        DialogueManager.onDialogueFinished += DialogueManager_onDialogueFinished;
    }

    private void DialogueManager_onDialogueFinished()
    {
        Debug.Log("PROLOGUE DONE");
        DialogueManager.onDialogueFinished -= DialogueManager_onDialogueFinished;
        SceneManager.LoadScene("Level");
    }
}
