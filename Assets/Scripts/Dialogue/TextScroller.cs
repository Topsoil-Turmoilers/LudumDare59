using TMPro;
using UnityEngine;

public class TextScroller : MonoBehaviour
{
    [SerializeField, Range(15f, 100f)] private float lettersPerSecond;
    private float scrollTime = 0;

    [SerializeField] private string scrollLine;
    [SerializeField] private string displayName;
    [SerializeField] private DialogueObject currentDialogue;
    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private TextMeshProUGUI textDisplayJank;
    [SerializeField] private TextMeshProUGUI nameDisplay;
    //private void Awake()
    //{
    //    textDisplay = GetComponent<TextMeshProUGUI>();
    //}

    private void Start()
    {

    }

    public void StartDialogue(DialogueObject dialogue)
    {
        currentDialogue = dialogue;
        RunLine(currentDialogue.Begin());
    }
    /// <summary>
    /// Returns TRUE when there is more dialogue to play, returns FALSE when there is no more dialogue
    /// </summary>
    /// <returns></returns>
    public bool Continue()
    {
        string dialogue = currentDialogue.NextLine();
        if(dialogue == "")
        {
            //dialogue is over
            return false;
        }
        else
        {
            RunLine(dialogue);
            return true;
        }
    }

    private void RunLine(string line)
    {
        textDisplay.text = "";
        scrollLine = line;
        textDisplayJank.text = line;
        
        nameDisplay.text = currentDialogue.CurrentName;
        AudioManager.instance?.PlayDialogueSFX(currentDialogue.CurrentSFX);
    }

    private void Update()
    {
        if (scrollLine.Length <= 0) return;
        float lps = 1 / lettersPerSecond;
        scrollTime += Time.deltaTime;
        while (scrollTime > lps && scrollLine.Length > 0)
        {
            scrollTime -= lps;
            textDisplay.text += scrollLine[0];
            textDisplay.fontSize = textDisplayJank.fontSize;
            scrollLine = scrollLine.Substring(1, scrollLine.Length - 1);
        }

        Debug.Log(textDisplay.rectTransform.rect.y);
    }


}
