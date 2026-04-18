using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class StoryFlagManager : MonoBehaviour
{
    public static StoryFlagManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        SetupStoryFlagDictionary();
    }

    public enum StoryFlag {CheckRadio};

    //public Dictionary<StoryFlag, string> StoryFlagDescription;

    public List<StoryFlag> StoryFlags;
    public List<bool> StoryFlagsValues;
    public List<string> StoryFlagsDescriptions;

    private Dictionary<StoryFlag, bool> StoryFlagValues;

    private void SetupStoryFlagDictionary()
    {
        StoryFlagValues = new Dictionary<StoryFlag, bool>();
        for (int i = 0; i < StoryFlagValues.Count; i++)
        {
            StoryFlagValues.Add(StoryFlags[i], StoryFlagsValues[i]);
        }
    }
    public void ClearFlags()
    {
        foreach(StoryFlag flag in Enum.GetValues(typeof(StoryFlag)))
        {
            setFlag(flag, false);
        }
    }

    public bool checkFlag(StoryFlag flag)
    { 
        StoryFlagValues.TryGetValue(flag, out bool value);
        return value;
    }

    public void setFlag(StoryFlag flag, bool value)
    {
        if (!StoryFlagValues.ContainsKey(flag))
        {
            StoryFlagValues.Add(flag, value);
        }
        else
        {
            StoryFlagValues[flag] = value;
        }
            
    }

    //[System.Serializable]
    //public struct StoryFlagInternal
    //{
    //    public StoryFlag Flag;
    //    public string description;
    //    public bool value;
    //}
}
