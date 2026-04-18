using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class PlayerMain : MonoBehaviour
{
    //Variables

    [Header ("Components")]
    public PlayerData playerData;
    [HideInInspector] public Animator anim;
    [HideInInspector] public Rigidbody2D rBody;
    [HideInInspector] public SpriteRenderer sRend;

    [Header("States")] //Put all States here
    public PlayerBaseState currentState;
    public PlayerStateWalk WalkState = new PlayerStateWalk();
    public PlayerStateSprint SprintState = new PlayerStateSprint();

    [Header("Stats")]
    public Vector2 moveInput;
    public float RunStamina; //Done here so it can change with a stamina bar
    public bool canSprint;

    //Main

    private void Awake()
    {
        //Initializing Components
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();

        RunStamina = playerData.runStamina;
        canSprint = true;
    }

    private void Start()
    {
        SwitchState(WalkState);
    }

    private void Update()
    {
        //Update inside State
        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        //FixedUpdate inside State
        currentState.FixedUpdateState(this);
    }

    private void LateUpdate()
    {
        //LateUpdate inside State
        currentState.LateUpdateState(this);
    }

    public void SwitchState(PlayerBaseState newState)
    {
        //Exiting State
        if (currentState != null) //Safety Check!
        {
            currentState.ExitState(this);
        }

        //Switching States
        currentState = newState;

        //Entering State
        currentState.EnterState(this);
    }

    //Event System
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (canSprint && context.performed) //Only Sprint if you can and if held
        {
            SwitchState(SprintState);
        }

        if (context.canceled) //If sprint is let go early, go back to walk
        {
            SwitchState(WalkState);
        }
    }

    //Helpers

    //Flips the Sprite
    public void FlipSprite(float hVelocity)
    {
        if (Mathf.Abs(hVelocity) > 0.1f)
        {
            float direction = hVelocity > 0 ? 1f : -1f;
            Vector3 newScale = anim.transform.localScale;
            newScale.x = direction;
            anim.transform.localScale = newScale;
        }
    }
}
