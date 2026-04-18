using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Scriptable Objects/Dialogue Object", order = 1)]
public class DialogueObject : ScriptableObject
{
    [SerializeField] private int _currentLine;

    [SerializeField] public string[] lines;
    //[SerializeField] public AudioEnum[] lineSFX;
    public string CurrentLine { 
        get { 
            return lines[_currentLine]; 
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
            return "";
        }else return lines[_currentLine];
    }

}
