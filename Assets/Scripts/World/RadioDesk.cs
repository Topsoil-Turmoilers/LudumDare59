using UnityEngine;

public class RadioDesk : MonoBehaviour, IInteractable
{
    [SerializeField] private RadioUIManager radioUIManager;
    [SerializeField] private bool isUsable;
    [SerializeField] private DialogueObject whenNotUsable;

    private void Awake()
    {
        radioUIManager = FindFirstObjectByType<RadioUIManager>();
        if (radioUIManager == null) Debug.LogWarning("Please Ensure the RadioDesk is in the same scene as a RadioUIManager");

    }
    public void OnInteract()
    {
        if (isUsable)
        {
            radioUIManager.OpenRadioUI();
        }
        else
        {
            DialogueManager.instance.StartDialogue(whenNotUsable);
        }
    }

    public void DisableRadio()
    {
        isUsable = false;
    }
    public void EnableRadio()
    {
        isUsable = true;
    }
}
