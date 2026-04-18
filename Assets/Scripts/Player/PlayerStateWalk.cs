using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateWalk : PlayerBaseState
{
    //When a State is Entered
    public override void EnterState(PlayerMain player)
    {
        
    }

    //When Update Runs in a State
    public override void UpdateState(PlayerMain player)
    {
        player.StaminaRegen();
    }

    //When FixedUpdate Runs in a State
    public override void FixedUpdateState(PlayerMain player)
    {
        //Flips Sprite based on Movement
        player.FlipSprite(player.moveInput.x);

        //Moves player based on input and walk speed
        player.rBody.linearVelocity = new Vector2(player.moveInput.x * player.playerData.walkSpeed, player.moveInput.y * player.playerData.walkSpeed);
    }

    //When LateUpdate Runs in a State
    public override void LateUpdateState(PlayerMain player)
    {
        
    }

    //When a State is Exited
    public override void ExitState(PlayerMain player)
    {
        
    }

    public override void OnSprint(InputAction.CallbackContext context, PlayerMain player)
    {
        if (player.canSprint && context.performed) //Only Sprint if you can and if held
        {
            player.SwitchState(player.SprintState);
        }
    }
}
