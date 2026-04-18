using UnityEngine;

public class PlayerStateInteract : PlayerBaseState
{
    //When a State is Entered
    public override void EnterState(PlayerMain player)
    {
        //Stops all player movement
        player.rBody.linearVelocity = new Vector2(0, 0);
    }

    //When Update Runs in a State
    public override void UpdateState(PlayerMain player)
    {

    }

    //When FixedUpdate Runs in a State
    public override void FixedUpdateState(PlayerMain player)
    {

    }

    //When LateUpdate Runs in a State
    public override void LateUpdateState(PlayerMain player)
    {

    }

    //When a State is Exited
    public override void ExitState(PlayerMain player)
    {

    }
}
