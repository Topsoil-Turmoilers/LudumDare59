using UnityEngine;

public class FakePlayer : MonoBehaviour
{
    //This is for the end cutscene's fake player. (And the shuttle technically)

    [SerializeField] private PlayerData playerData;

    private Animator anim;
    private Rigidbody2D rBody;
    private SpriteRenderer sRend;

    [SerializeField] private GameObject shuttle;
    private Rigidbody2D shuttleRBody;

    [SerializeField] private BlackScreenFades blackScreen;

    //Bool Triggers
    [SerializeField] private bool walkToShuttleDone = false;
    [SerializeField] private bool shuttleGone = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();

        shuttleRBody = shuttle.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerCutsceneMovement();
    }

    public void PlayerCutsceneMovement()
    {
        if (!walkToShuttleDone) { blackScreen.FadeOut(); WalkIntoShuttle(); return; }
        if (!shuttleGone) { ShuttleTakeOff(); return; }
        blackScreen.FadeIn();
    }

    public void WalkIntoShuttle()
    {
        anim.SetBool("isWalking", true);
        anim.SetFloat("InputX", 1);
        anim.SetFloat("InputY", 0);

        if (transform.position.x < 0)
        {
            rBody.linearVelocity = new Vector2(1 * playerData.walkSpeed, 0);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetFloat("InputX", 0);
            anim.SetFloat("InputY", 0);

            rBody.linearVelocity = new Vector2(0, 0);
            transform.position = new Vector2(0, transform.position.y);
            walkToShuttleDone = true;
        }
    }

    public void ShuttleTakeOff()
    {
        if (shuttle.transform.position.y < 8)
        {
            rBody.linearVelocity = new Vector2(0, 5);
            shuttleRBody.linearVelocity = new Vector2(0, 5);
        }
        else
        {
            rBody.linearVelocity = new Vector2(0, 0);
            shuttleRBody.linearVelocity = new Vector2(0, 0);
            shuttleGone = true;
        }
    }
}
