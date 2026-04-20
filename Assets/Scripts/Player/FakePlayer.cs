using System.Collections;
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
    private ParticleSystem shuttleParticles;

    [SerializeField] private BlackScreenFades blackScreen;

    //Bool Triggers
    [SerializeField] private bool walkToShuttleDone = false;
    [SerializeField] private bool BackNShakeDone = false;
    private float downShuttleSpeed = -3;
    private float shakyTimer = 0;
    private bool direction = false;
    [SerializeField] private bool shuttleGone = false;
    [SerializeField] private bool shuttleStart = false;
    private float shuttleSpeed = 5;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();

        shuttleRBody = shuttle.GetComponent<Rigidbody2D>();
        shuttleParticles = shuttle.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        PlayerCutsceneMovement();
    }

    public void PlayerCutsceneMovement()
    {
        if (!walkToShuttleDone) { blackScreen.FadeOut(); WalkIntoShuttle(); return; } //FadeOut Black Screen and Walk into Shuttle

        //Shuttle Movement
        shuttleParticles.Play();
        if (!shuttleGone) { ShakyLeftRight(); } //Shaky left right :)
        if (!BackNShakeDone) { SmallPushBackwards(); return; } //Goes down first
        if (!shuttleGone && shuttleStart) { ShuttleTakeOff(); return; } //Then shoots up

        if (shuttleGone) { shuttleParticles.Stop(); blackScreen.FadeIn(); } //Shuttle is gone, so FadeIn Black Screen
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

    public void SmallPushBackwards()
    {
        downShuttleSpeed += -0.1f;
        //Down
        if (shuttle.transform.position.y > 0)
        {
            rBody.linearVelocity = new Vector2(0, downShuttleSpeed);
            shuttleRBody.linearVelocity = new Vector2(0, downShuttleSpeed);
        }
        else
        {
            rBody.linearVelocity = new Vector2(0, 0);
            shuttleRBody.linearVelocity = new Vector2(0, 0);
            BackNShakeDone = true;
            StartCoroutine(WaitingBeforeStart(1f));
        }
    }

    public void ShakyLeftRight()
    {
        //Debug.Log(shakyTimer);

        //Flippy direction
        if (shakyTimer >= 10) { direction = false; }
        if (shakyTimer <= -10) { direction = true; }

        //Go Left Right
        if (direction)
        {
            shakyTimer += 0.5f;
            rBody.linearVelocity = new Vector2(-3, rBody.linearVelocity.y);
            shuttleRBody.linearVelocity = new Vector2(-3, rBody.linearVelocity.y);
        }
        else
        {
            shakyTimer -= 0.5f;
            rBody.linearVelocity = new Vector2(3, rBody.linearVelocity.y);
            shuttleRBody.linearVelocity = new Vector2(3, rBody.linearVelocity.y);
        }
    }

    private IEnumerator WaitingBeforeStart(float amount)
    {
        yield return new WaitForSeconds(amount);
        shuttleStart = true;
    }

    public void ShuttleTakeOff()
    {
        shuttleSpeed += 1;
        if (shuttle.transform.position.y < 20)
        {
            rBody.linearVelocity = new Vector2(0, shuttleSpeed);
            shuttleRBody.linearVelocity = new Vector2(0, shuttleSpeed);
        }
        else
        {
            rBody.linearVelocity = new Vector2(0, 0);
            shuttleRBody.linearVelocity = new Vector2(0, 0);
            shuttleGone = true;
        }
    }
}
