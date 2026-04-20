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

    public enum StoryFlag {None, GameStarted, CheckedRadio, ReportedSharpsDeath, ListFound, MossContacted, MossRescued, LeftToFindBag, BagFound, ScientistsContacted,
                             ScientistsRescued, LeblancWalkieLocated, DuchampLocated, ResearchNotesFound, ItLuredAway, DuchampContacted, DuchampRescued, AntennaBroken, AntennaRepaired, AllRescued, CrumpledNoteFound};

    //public Dictionary<StoryFlag, string> StoryFlagDescription;

    public List<StoryFlag> StoryFlags;
    public List<bool> StoryFlagsValues;
    public List<string> StoryFlagsDescriptions;

    private Dictionary<StoryFlag, bool> StoryFlagValues;
    public Dictionary<StoryFlag, bool> StoryFlagValuesReadonly { get {  return StoryFlagValues; } }

    private void SetupStoryFlagDictionary()
    {
        StoryFlagValues = new Dictionary<StoryFlag, bool>();
        for (int i = 0; i < StoryFlagsValues.Count; i++)
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
}
