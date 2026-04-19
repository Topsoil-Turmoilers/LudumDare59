using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Playlist")]
    [SerializeField] private AudioPlaylist playlist;

    [Header("Music")]
    [SerializeField] private AudioSource musicSource;

    [Header("SFX")]
    [SerializeField] private AudioSource sfxSource;

    private void Awake()
    {
        if(instance == null)
        {
            //Instanciate the AudioManager
            instance = this;

            //Persists across scenes even though we're planning to stick to one
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //If there is already an Audiomanager, a new one will not be created
            Destroy(gameObject);
        }
    }

    private void Start()
    { 
            //Safety check -> Plays Menu Music by Default
        if (playlist != null && playlist.menuTheme != null)
        {
            PlayMenuMusic();
        }
    }

    // MUSIC ===========================================================
    public void PlayMenuMusic() => PlayMusic(playlist.menuTheme);
    public void PlayPrologueMusic() => PlayMusic(playlist.prologueTheme);
    public void PlayInsideMusic() => PlayMusic(playlist.insideTheme);
    public void PlayOutsideMusic() => PlayMusic(playlist.outsideTheme);

    // SFX =============================================================

        // RADIO SFX
    public void PlayRadioButton01SFX() => sfxSource.PlayOneShot(playlist.radioButton01);
    public void PlayRadioButton02SFX() => sfxSource.PlayOneShot(playlist.radioButton02);
    public void PlayRadioHighfqSFX() => sfxSource.PlayOneShot(playlist.radioPlayingHighFQ);
    public void PlayRadioLowfqSFX() => sfxSource.PlayOneShot(playlist.radioPlayingLowFQ);
    public void PlayRadioOffKeyfqSFX() => sfxSource.PlayOneShot(playlist.radioPlayingOffKeyFQ);

        // INSIDE SFX
    public void PlayWalkInsideSFX() => sfxSource.PlayOneShot(playlist.walkInside);
    public void PlayWindowHitSFX() => sfxSource.PlayOneShot(playlist.windowHit);
    public void PlayWindowKnockSFX() => sfxSource.PlayOneShot(playlist.windowKnock);
    public void PlayWindowSingleTapSFX() => sfxSource.PlayOneShot(playlist.windowSingleTap);
    public void PlayWindowTapSFX() => sfxSource.PlayOneShot(playlist.windowTap);

    // OUTSIDE SFX
    public void PlayWalkOutsideSFX() => sfxSource.PlayOneShot(playlist.walkOutside);
    public void PlayFlashlightOnSFX() => sfxSource.PlayOneShot(playlist.flashlightOn);
    public void PlayFlashlightOffSFX() => sfxSource.PlayOneShot(playlist.flashlightOff);
    public void PlayFlashlightRattleSFX() => sfxSource.PlayOneShot(playlist.flashlightRattle);
    public void PlayFlashlightHitSFX() => sfxSource.PlayOneShot(playlist.flashlightHit);

    //==================================================================
    private void PlayMusic(AudioClip clip)
    {
        if(musicSource.clip == clip)
        {
            //If the clip is already playing, do not restart it
            return;
        }

        musicSource.clip = clip;
        musicSource.Play();
    }
}
