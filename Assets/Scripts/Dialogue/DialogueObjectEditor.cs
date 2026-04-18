#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DialogueObject))]
public class DialogueObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        SerializedProperty DialogueList = serializedObject.FindProperty("lines");
        for (int i = 0; i < DialogueList.arraySize; i++)
        {
            DialogueList.GetArrayElementAtIndex(i).stringValue = GUILayout.TextArea(DialogueList.GetArrayElementAtIndex(i).stringValue);
        }


        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("+"))
        {
            DialogueList.InsertArrayElementAtIndex(DialogueList.arraySize);
        }
        if (GUILayout.Button("-", GUILayout.MaxWidth(20f)))
        {
            DialogueList.DeleteArrayElementAtIndex(DialogueList.arraySize - 1);
        }
        EditorGUILayout.EndHorizontal();
        serializedObject.ApplyModifiedProperties();
    }
}
#endif