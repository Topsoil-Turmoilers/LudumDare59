using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueObject dialogue;

    public UnityEvent OnDialogueFinished;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!this.enabled) return;
        if (dialogue != null && collision.TryGetComponent<PlayerMain>(out PlayerMain player))
        {
            player.SwitchState(player.InteractState);
            DialogueManager.instance.StartDialogue(dialogue);
            DialogueManager.onDialogueFinished += DialogueManager_onDialogueFinished; 
            this.enabled = false;
        }
    }

    private void DialogueManager_onDialogueFinished()
    {
        OnDialogueFinished.Invoke();
        DialogueManager.onDialogueFinished -= DialogueManager_onDialogueFinished;
    }
}
