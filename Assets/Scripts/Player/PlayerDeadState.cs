using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    private bool stopUpdating;
    private float deathTimer = 1f;
    public override void EnterState(PlayerMain player)
    {
        stopUpdating = false;
        deathTimer = 1f;
        //throw new System.NotImplementedException();

        if (player = null) { player = player.GetComponent<PlayerMain>(); }
    }

    public override void ExitState(PlayerMain player)
    {
        Debug.Log("Why am I exiting the Dead State??");
        stopUpdating = false;
        if (player != null)
        {
            player.transform.rotation = Quaternion.identity;
        }
    }

    public override void FixedUpdateState(PlayerMain player)
    {
        //throw new System.NotImplementedException();
    }

    public override void LateUpdateState(PlayerMain player)
    {
        //throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerMain player)
    {
        if (stopUpdating) return;
        deathTimer -= Time.deltaTime;
        player.transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, 90), Quaternion.identity, 
            deathTimer < 0 ? 0 : deathTimer * deathTimer);
        player.rBody.linearVelocity = new Vector2(0, 0);

        if (deathTimer <= -1.5f)
        {
            //1 second after 'fully rotating'
            GameOverOverlay.Instance.OnGameOver();
            stopUpdating = true;
        }
    }
}
