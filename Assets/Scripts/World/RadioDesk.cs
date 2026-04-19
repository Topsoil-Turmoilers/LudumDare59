using UnityEngine;

public class RadioDesk : MonoBehaviour, IInteractable
{
    [SerializeField] private RadioUIManager radioUIManager;
    public void OnInteract()
    {
        radioUIManager.OpenRadioUI();
    }
}
