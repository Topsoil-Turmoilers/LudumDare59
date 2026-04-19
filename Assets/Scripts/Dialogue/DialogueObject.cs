using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Scriptable Objects/Dialogue Object", order = 1)]
public class DialogueObject : ScriptableObject
{
    [SerializeField] private int _currentLine;

    [SerializeField] public string[] names;
    [SerializeField] public string[] lines;
    [SerializeField] public SFX[] lineSFX;
    [SerializeField] public StoryFlagManager.StoryFlag flag;
    //[SerializeField] public AudioEnum[] lineSFX;
    public string CurrentLine { 
        get { 
            return lines[_currentLine]; 
        } 
    }
    public string CurrentName
    {
        get
        {
            return names[_currentLine];
        }
    }
    public SFX CurrentSFX
    {
        get
        {
            return lineSFX[_currentLine];
        }
    }
    public string Begin()
    {
        _currentLine = 0;
        return lines[_currentLine];
    }

    public string NextLine()
    {
        _currentLine++;
        if (_currentLine >= lines.Length)
        {
            StoryFlagManager.instance.setFlag(flag, true);
            return "";
        }
        else return lines[_currentLine];
    }

}
