using UnityEngine;
using UnityEngine.InputSystem;

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

    [Header("Stats")]
    public Vector2 moveInput;

    //Main
    private void Awake()
    {
        //Initializing Components
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        //Switch to main walking state
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
        //switch to sprint state
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
