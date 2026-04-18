using UnityEngine;

public class StoryFlagTrigger : MonoBehaviour
{
    [SerializeField] private StoryFlagManager.StoryFlag TriggerFlag;

    public void Activate()
    {
        StoryFlagManager.instance.setFlag(TriggerFlag, true);
    }
}
