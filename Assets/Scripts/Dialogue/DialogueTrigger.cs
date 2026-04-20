using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueObject dialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!this.enabled) return;
        if (dialogue != null && collision.TryGetComponent<PlayerMain>(out PlayerMain player))
        {
            player.SwitchState(player.InteractState);
            DialogueManager.instance.StartDialogue(dialogue);
            this.enabled = false;
        }
    }
}
