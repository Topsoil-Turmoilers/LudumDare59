using TMPro;
using UnityEngine;

public class NotebookController : MonoBehaviour
{
    [SerializeField] private GameObject NoteCaptain1;
    [SerializeField] private GameObject NoteCaptain2;

    [SerializeField] private GameObject NoteMedic1;
    [SerializeField] private GameObject NoteMedic2;
    [SerializeField] private GameObject NoteMedic3;

    [SerializeField] private GameObject NoteGeologist1;
    [SerializeField] private GameObject NoteGeologist2;


    [SerializeField] private GameObject NoteBiologist1;
    [SerializeField] private GameObject NoteBiologist2;
    [SerializeField] private GameObject NoteBiologist3;

    [SerializeField] private GameObject NoteAnalyst1;
    [SerializeField] private GameObject NoteAnalyst2;
    [SerializeField] private GameObject NoteAnalyst3;
    [SerializeField] private GameObject NoteAnalyst4;
    [SerializeField] private GameObject NoteAnalyst5;


    private void OnEnable()
    {
        if (StoryFlagManager.instance.checkFlag(StoryFlagManager.StoryFlag.CheckedRadio)) 
            NoteCaptain1.SetActive(true);
        if (StoryFlagManager.instance.checkFlag(StoryFlagManager.StoryFlag.CheckedRadio)) 
            NoteCaptain2.SetActive(true);
        if (StoryFlagManager.instance.checkFlag(StoryFlagManager.StoryFlag.CheckedRadio))
            NoteMedic1.SetActive(true);
        if (StoryFlagManager.instance.checkFlag(StoryFlagManager.StoryFlag.ListFound))
            NoteMedic2.SetActive(true);
        if (StoryFlagManager.instance.checkFlag(StoryFlagManager.StoryFlag.MossContacted))
            NoteMedic3.SetActive(true);
        if (StoryFlagManager.instance.checkFlag(StoryFlagManager.StoryFlag.BagFound))
            NoteGeologist1.SetActive(true);
        if (StoryFlagManager.instance.checkFlag(StoryFlagManager.StoryFlag.CrumpledNoteFound))
            NoteGeologist2.SetActive(true);
        if (StoryFlagManager.instance.checkFlag(StoryFlagManager.StoryFlag.ScientistsContacted))
            NoteBiologist1.SetActive(true);
        if (StoryFlagManager.instance.checkFlag(StoryFlagManager.StoryFlag.ScientistsContacted))
            NoteBiologist2.SetActive(true);
        if (StoryFlagManager.instance.checkFlag(StoryFlagManager.StoryFlag.LeblancWalkieLocated))
            NoteBiologist3.SetActive(true);
        if (StoryFlagManager.instance.checkFlag(StoryFlagManager.StoryFlag.ScientistsContacted))
            NoteAnalyst1.SetActive(true);
        if (StoryFlagManager.instance.checkFlag(StoryFlagManager.StoryFlag.DuchampLocated))
            NoteAnalyst2.SetActive(true);
        if (StoryFlagManager.instance.checkFlag(StoryFlagManager.StoryFlag.ResearchNotesFound))
            NoteAnalyst3.SetActive(true);
        if (StoryFlagManager.instance.checkFlag(StoryFlagManager.StoryFlag.ItLuredAway))
            NoteAnalyst4.SetActive(true);
        if (StoryFlagManager.instance.checkFlag(StoryFlagManager.StoryFlag.AllRescued))
            NoteAnalyst5.SetActive(true);
    }
}
