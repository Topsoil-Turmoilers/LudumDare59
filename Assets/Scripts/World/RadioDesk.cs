using UnityEngine;

public class RadioDesk : MonoBehaviour, IInteractable
{
    [SerializeField] private RadioUIManager radioUIManager;

    private void Awake()
    {
        radioUIManager = FindFirstObjectByType<RadioUIManager>();
        if (radioUIManager == null) Debug.LogWarning("Please Ensure the RadioDesk is in the same scene as a RadioUIManager");

    }
    public void OnInteract()
    {
        radioUIManager.OpenRadioUI();
    }
}
