#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

[CustomEditor(typeof(DialogueObject))]
public class DialogueObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DialogueObject dialogue = (DialogueObject)target;
        SerializedProperty NamesList = serializedObject.FindProperty("names");
        SerializedProperty DialogueList = serializedObject.FindProperty("lines");
        SerializedProperty SFXEnumList = serializedObject.FindProperty("lineSFX");

        SerializedProperty FlagSetByConversation = serializedObject.FindProperty("flag");

        FlagSetByConversation.SetEnumValue(EditorGUILayout.EnumPopup("Story Flag to Set:", FlagSetByConversation.GetEnumValue<StoryFlagManager.StoryFlag>()));

        for (int i = 0; i < DialogueList.arraySize; i++)
        {
            EditorGUILayout.BeginHorizontal();

            //the text which appears in the Name box
            GUILayout.Label("Speaker:");
            if (NamesList.arraySize <= i) NamesList.InsertArrayElementAtIndex(i);
            NamesList.GetArrayElementAtIndex(i).stringValue = GUILayout.TextField(NamesList.GetArrayElementAtIndex(i).stringValue, GUILayout.MinWidth(120f), GUILayout.ExpandWidth(false));

            //the Sound Effect that plays when the dialogue node begins
            GUILayout.Label("SFX:");
            if (SFXEnumList.arraySize <= i) SFXEnumList.InsertArrayElementAtIndex(i);
            SFXEnumList.GetArrayElementAtIndex(i).SetEnumValue(EditorGUILayout.EnumPopup(SFXEnumList.GetArrayElementAtIndex(i).GetEnumValue<SFX>(), GUILayout.MaxWidth(150f)));
            EditorGUILayout.EndHorizontal();

            //the text that fills the text box
            DialogueList.GetArrayElementAtIndex(i).stringValue = GUILayout.TextArea(DialogueList.GetArrayElementAtIndex(i).stringValue);

            GUILayout.Box("", new GUILayoutOption[] { GUILayout.ExpandWidth(true), GUILayout.Height(1) });
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