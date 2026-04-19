using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MonsterTimer : MonoBehaviour
{
    public PlayerMain player;
    public Volume screenVolume;
    public Vignette vignette;

    [SerializeField] private bool isMonsterActive = false;
    [SerializeField] private bool isMonsterTime = false;
    public bool IsMonsterTime {  get { return isMonsterTime; } }
    [SerializeField] private float monsterTimeTimer;
    [SerializeField] private float transitionTimer;

    [SerializeField] private float standardIntensity = 0.2f;
    [SerializeField] private float monsterTimeIntensity = 0.6f;

    private void Start()
    {
        screenVolume.profile.TryGet<Vignette>(out vignette);
    }

    private void Update()
    {
        if (monsterTimeTimer > 0) monsterTimeTimer -= Time.deltaTime;
        if (transitionTimer > 0) transitionTimer -= Time.deltaTime;

        if (isMonsterTime)
        {
            vignette.intensity.value = Mathf.Lerp(monsterTimeIntensity, standardIntensity, transitionTimer);
            if (monsterTimeTimer <= 0) EndMonsterTime();
        }
        else
        {
            vignette.intensity.value = Mathf.Lerp(standardIntensity, monsterTimeIntensity, transitionTimer);
            if (monsterTimeTimer <= 0 && isMonsterActive) StartMonsterTime();
        }
        vignette.intensity.value += 0.5f - (player.PlayerHealth / 10f);
    }
    private void FixedUpdate()
    {
        TryHurtPlayer();
    }

    public void StartMonsterActivity()
    {
        isMonsterActive = true;
        StartMonsterTime();
    }
    public void PauseMonsterActivity()
    {
        isMonsterActive = false;
        EndMonsterTime();
    }
    private void StartMonsterTime()
    {
        monsterTimeTimer = 35f;
        isMonsterTime = true;
        transitionTimer = 5f;
        AudioManager.instance?.PlayRadioOffKeyfqSFX();
    }
    private void EndMonsterTime()
    {
        monsterTimeTimer = Random.Range(60f, 180f);
        isMonsterTime = false;
        transitionTimer = 3f;
    }
    private void TryHurtPlayer()
    {
        //if it is monster time, the player is not inside, and we are not in the transition phase of monster time
        if(IsMonsterTime && !player.isInside)
        {
            if(transitionTimer <= 0)
            {
                if(player.PlayerHealth >= 4.9)
                {
                    AudioManager.instance?.PlayRadioOffKeyfqSFX();
                }
                player.PlayerHealth -= Time.fixedDeltaTime;
            }
        }
        else
        {
            player.PlayerHealth += Time.fixedDeltaTime;
        }
    }
}
