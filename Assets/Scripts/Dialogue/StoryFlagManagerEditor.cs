#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using static StoryFlagManager;

[CustomEditor(typeof(StoryFlagManager))]
public class StoryFlagManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (Application.isPlaying)
        {
            DisplayAtRuntime((StoryFlagManager)target);
            return;
        }
        
        serializedObject.Update();
        SerializedProperty FlagList = serializedObject.FindProperty("StoryFlags");
        SerializedProperty BoolList = serializedObject.FindProperty("StoryFlagsValues");
        SerializedProperty DescList = serializedObject.FindProperty("StoryFlagsDescriptions");
        StoryFlagManager StoryManager = (StoryFlagManager)target;
        Array StoryFlags = Enum.GetValues(typeof(StoryFlagManager.StoryFlag));

        for (int i = 0; i < StoryFlags.Length; i++)
        {

            //EditorGUI.BeginChangeCheck();
            if (FlagList.arraySize <= i)
            //if (i > StoryFlagList.Count)
            {
                FlagList.InsertArrayElementAtIndex(i);
                FlagList.GetArrayElementAtIndex(i).SetEnumValue((StoryFlagManager.StoryFlag)StoryFlags.GetValue(i));
                BoolList.InsertArrayElementAtIndex(i);
                DescList.InsertArrayElementAtIndex(i);
                //StoryManager.StoryFlags.Add(new StoryFlagManager.StoryFlagInternal());
            }

            EditorGUILayout.BeginVertical();
            EditorGUILayout.BeginHorizontal();

            //InternalFlag.Flag = (StoryFlagManager.StoryFlag) StoryFlags.GetValue(i);
            BoolList.GetArrayElementAtIndex(i).boolValue = EditorGUILayout.Toggle(BoolList.GetArrayElementAtIndex(i).boolValue);
            //InternalFlag.value = EditorGUILayout.Toggle(StoryManager.StoryFlags[i].value);
            EditorGUILayout.LabelField(FlagList.GetArrayElementAtIndex(i).GetEnumName<StoryFlagManager.StoryFlag>());
            //GUILayout.Label(InternalFlag.Flag.ToString());
            EditorGUILayout.EndHorizontal();
            DescList.GetArrayElementAtIndex(i).stringValue = EditorGUILayout.TextField(DescList.GetArrayElementAtIndex(i).stringValue);
            //InternalFlag.description = GUILayout.TextField(StoryManager.StoryFlags[i].description);
            EditorGUILayout.EndVertical();
            //StoryManager.StoryFlags[i] = InternalFlag;
            //if(EditorGUI.EndChangeCheck()){
            //    EditorUtility.SetDirty(this);
            //    AssetDatabase.SaveAssets();
            //}

        }
        serializedObject.ApplyModifiedProperties();
    }
    private void DisplayAtRuntime(StoryFlagManager sfm)
    {
        EditorGUILayout.LabelField("The StoryFlagManager becomes Readonly at Runime. You have been warned");
        for (int i = 0; i < sfm.StoryFlagValuesReadonly.Count; i++)
        {
            EditorGUILayout.BeginVertical();
            EditorGUILayout.BeginHorizontal();

            //InternalFlag.Flag = (StoryFlagManager.StoryFlag) StoryFlags.GetValue(i);
            EditorGUILayout.Toggle(sfm.StoryFlagValuesReadonly.Values.ToArray()[i]);
            //InternalFlag.value = EditorGUILayout.Toggle(StoryManager.StoryFlags[i].value);
            EditorGUILayout.LabelField(sfm.StoryFlagValuesReadonly.Keys.ToArray()[i].ToString());
            //GUILayout.Label(InternalFlag.Flag.ToString());
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.TextField(sfm.StoryFlagsDescriptions[i]);
            //InternalFlag.description = GUILayout.TextField(StoryManager.StoryFlags[i].description);
            EditorGUILayout.EndVertical();
        }
        return;
    }
}
#endif
