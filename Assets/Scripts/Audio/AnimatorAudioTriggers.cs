using UnityEngine;
using System.Collections;

//This script will trigger audio clips during animator events instead of each frame.

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
