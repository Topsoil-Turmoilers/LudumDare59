using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionHook : MonoBehaviour
{
    [SerializeField] private DialogueObject defaultDialogue;
    [SerializeField] public List<ConditionalDialogue> conditionalDialogue;

    public UnityEvent OnDefaultDialogueFinished;

    public void OnInteract()
    {
        for(int i = conditionalDialogue.Count - 1; i >= 0; i--)
        {
            ConditionalDialogue cd = conditionalDialogue[i];
            if (StoryFlagManager.instance.checkFlag(cd.requiredStoryFlag)){
                DialogueManager.instance.StartDialogue(cd.dialogue);
                StoryFlagManager.instance.setFlag(cd.storyFlagToTrigger, true);
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
        public DialogueObject dialogue;
        
        public StoryFlagManager.StoryFlag storyFlagToTrigger;
    }
}
