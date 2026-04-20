using TMPro;
using UnityEngine;

public class NotebookController : MonoBehaviour
{
    [SerializeField] private GameObject NotesLineCaptain;
    [SerializeField] private GameObject NotesLineCaptain2;

    private void OnEnable()
    {
        if (StoryFlagManager.instance.checkFlag(StoryFlagManager.StoryFlag.CheckedRadio)) 
            NotesLineCaptain.SetActive(true);
        if (StoryFlagManager.instance.checkFlag(StoryFlagManager.StoryFlag.CheckedRadio)) 
            NotesLineCaptain2.SetActive(true);
    }
}
