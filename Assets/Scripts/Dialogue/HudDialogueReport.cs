using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

public class HudDialogueReport : MonoBehaviour
{
    [SerializeField] private DialogueObject defaultDialogue;
    [SerializeField] public List<ConditionalDialogue> conditionalDialogue;

    public UnityEvent OnDefaultDialogueFinished;

    public void OnInteract()
    {
        for (int i = 0; i < conditionalDialogue.Count; i++)
        {
            ConditionalDialogue cd = conditionalDialogue[i];
            if (StoryFlagManager.instance.checkFlag(cd.requiredStoryFlag) && !StoryFlagManager.instance.checkFlag(cd.ignoredAfterStoryFlag))
            {
                DialogueManager.instance.StartDialogue(cd.dialogue);
                DialogueManager.onDialogueFinished += cd.DialogueManager_onDialogueFinished;
                return;
            }
        }
        DialogueManager.onDialogueFinished += DialogueManager_onDialogueFinished;
        DialogueManager.instance.StartDialogue(defaultDialogue);
    }

    private void DialogueManager_onDialogueFinished()
    {
        OnDefaultDialogueFinished?.Invoke();
        DialogueManager.onDialogueFinished -= DialogueManager_onDialogueFinished;
    }

    [System.Serializable]
    public struct ConditionalDialogue
    {
        public StoryFlagManager.StoryFlag requiredStoryFlag;
        public StoryFlagManager.StoryFlag ignoredAfterStoryFlag;
        public DialogueObject dialogue;

        public UnityEvent onDialogueFinished;
        public void DialogueManager_onDialogueFinished()
        {
            onDialogueFinished?.Invoke();
            DialogueManager.onDialogueFinished -= DialogueManager_onDialogueFinished;
        }
    }
}
