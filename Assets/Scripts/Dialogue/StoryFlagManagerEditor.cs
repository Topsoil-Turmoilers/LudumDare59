#if UNITY_EDITOR
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.Rendering;

[CustomEditor(typeof(StoryFlagManager))]
public class StoryFlagManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
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
}
#endif
