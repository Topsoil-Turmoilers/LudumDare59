using UnityEngine;

public abstract class PlayerBaseState
{
    //When a State is Entered
    public abstract void EnterState(PlayerMain player);

    //When Update Runs in a State
    public abstract void UpdateState(PlayerMain player);

    //When FixedUpdate Runs in a State
    public abstract void FixedUpdateState(PlayerMain player);

    //When LateUpdate Runs in a State
    public abstract void LateUpdateState(PlayerMain player);

    //When a State is Exited
    public abstract void ExitState(PlayerMain player);
}
