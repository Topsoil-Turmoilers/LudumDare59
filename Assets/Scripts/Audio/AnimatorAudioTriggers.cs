using UnityEngine;
using System.Collections;

//This script will trigger audio clips during animator events instead of each frame.

public class AnimatorAudioTriggers : MonoBehaviour
{
    public void TriggerMovementSFX(PlayerMain player)
    {
        if(player.isWalking && player.isInside)
        {
            AudioManager.instance.PlayInsideWalkSFX();
        }

        if (player.isWalking && player.isOutside)
        {
            AudioManager.instance.PlayOutsideWalkSFX();
        }

        if(player.isRunning && player.isInside)
        {
            AudioManager.instance.PlayInsideRunSFX();
        }

        if(player.isRunning && player.isOutside)
        {
            AudioManager.instance.PlayOutsideRunSFX();
        }

        // Yes, I repeated myself over and over... woops. Has to be a better way to do this
    }
}
