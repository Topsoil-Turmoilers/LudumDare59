#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DialogueObject))]
public class DialogueObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DialogueObject obj = target as DialogueObject;
        if (obj == null) return;
        for(int i=0; i<obj.lines.Length; i++)
        {
            
            obj.lines[i] = GUILayout.TextArea(obj.lines[i]);
            
        }
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("+"))
        {
            string[] lines = new string[obj.lines.Length + 1];
            for (int i = 0; i < obj.lines.Length; i++)
            {
                lines[i] = obj.lines[i];
            }
            obj.lines = lines;
        }
        if (GUILayout.Button("-", GUILayout.MaxWidth(20f)))
        {
            string[] lines = new string[obj.lines.Length - 1];
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = obj.lines[i];
            }
            obj.lines = lines;
        }
        EditorGUILayout.EndHorizontal();

    }
}
#endif