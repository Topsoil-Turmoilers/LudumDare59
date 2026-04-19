using UnityEngine;
using System.Collections;

public class AnimatorAudioTriggers : MonoBehaviour
{
    public void TriggerWalkInsideSFX()
    {
        AudioManager.instance.PlayWalkInsideSFX();
    }

    public void TriggerWalkOutsideSFX()
    {
        AudioManager.instance.PlayRunInsideSFX();
    }
}
