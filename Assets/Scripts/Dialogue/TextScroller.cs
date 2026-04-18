using TMPro;
using UnityEngine;

public class TextScroller : MonoBehaviour
{
    [SerializeField, Range(15f, 100f)] private float lettersPerSecond;
    private float scrollTime = 0;

    [SerializeField] private string scrollLine;
    [SerializeField] private DialogueObject currentDialogue;
    private TextMeshProUGUI textDisplay;
    private void Awake()
    {
        textDisplay = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        StartDialogue(currentDialogue);
    }

    public void StartDialogue(DialogueObject dialogue)
    {
        currentDialogue = dialogue;
        scrollLine = currentDialogue.Begin();
        textDisplay.text = "";
    }
    /// <summary>
    /// Returns TRUE when there is more dialogue to play, returns FALSE when there is no more dialogue
    /// </summary>
    /// <returns></returns>
    public bool Continue()
    {
        textDisplay.text = "";
        string dialogue = currentDialogue.NextLine();
        if(dialogue == "")
        {
            //dialogue is over
            return false;
        }
        else
        {
            scrollLine = dialogue;
            return true;
        }
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
            scrollLine = scrollLine.Substring(1, scrollLine.Length - 1);
        }
    }


}
