using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateSprint : PlayerBaseState
{
    float runStaminaTimer; //How long they can run for
    
    //When a State is Entered
    public override void EnterState(PlayerMain player)
    {
        //Setting Timer to current stamina
        runStaminaTimer = player.RunStamina;

        //Making Animation faster
        player.anim.speed = 2;
    }

    //When Update Runs in a State
    public override void UpdateState(PlayerMain player)
    {
        if (runStaminaTimer > 0)
        {
            //Draining stamina
            runStaminaTimer -= Time.deltaTime;
            player.RunStamina = runStaminaTimer;
        }
        else
        {
            //Stamina ran out, so turn on recovery and switch back to walk
            player.canSprint = false;
            player.SwitchState(player.WalkState);
        }
    }

    //When FixedUpdate Runs in a State
    public override void FixedUpdateState(PlayerMain player)
    {
        //Moves player based on input and run speed
        player.rBody.linearVelocity = new Vector2(player.moveInput.x * player.playerData.runSpeed, player.moveInput.y * player.playerData.runSpeed);
    }

    //When LateUpdate Runs in a State
    public override void LateUpdateState(PlayerMain player)
    {
        
    }

    //When a State is Exited
    public override void ExitState(PlayerMain player)
    {
        //Returning Animation to previous speed
        player.anim.speed = 1;
    }

    public override void OnSprint(InputAction.CallbackContext context, PlayerMain player)
    {
        if (context.canceled) //If sprint is let go early, go back to walk
        {
            player.SwitchState(player.WalkState);
        }
    }
}
