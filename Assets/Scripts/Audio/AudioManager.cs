using UnityEngine;
using UnityEngine.SceneManagement;

public enum SFX { Static1, Static2, Static3, Flashlight1, Flashlight2, Flashlight3, Flashlight4, WindowHit, WindowTap, WindowTwotaps, WindowKnock}
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Playlist")]
    [SerializeField] private AudioPlaylist playlist;

    [Header("Music")]
    [SerializeField] private AudioSource musicSource;

    [Header("SFX")]
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource radioSfxSource;

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
        //this gets called every time a scene transition happens
        SceneManager.activeSceneChanged += LoadBGMOnSceneChange;
    }

    private void LoadBGMOnSceneChange(Scene formerScene, Scene newScene)
    {
        //0 is the title scene
        if(newScene.buildIndex == 0)
        {
            PlayMenuMusic();
        }
        //and we will never have more than 1 scene
        else
        {
            PlayOutsideMusic();
        }
    }

    // MUSIC ===========================================================
    public void PlayMenuMusic() => PlayMusic(playlist.menuTheme);
    public void PlayPrologueMusic() => PlayMusic(playlist.prologueTheme);
    public void PlayInsideMusic() => PlayMusic(playlist.insideTheme);
    public void PlayOutsideMusic() => PlayMusic(playlist.outsideTheme);

    // SFX =============================================================

        //PLAYER MOVEMENT
    public void PlayInsideWalkSFX() => sfxSource.PlayOneShot(playlist.insideWalk);
    public void PlayOutsideWalkSFX() => sfxSource.PlayOneShot(playlist.outsideWalk);
    public void PlayInsideRunSFX() => sfxSource.PlayOneShot(playlist.insideRun);
    public void PlayOutsideRunSFX() => sfxSource.PlayOneShot(playlist.outsideRun);

        // RADIO SFX
    public void PlayRadioButton01SFX() => sfxSource.PlayOneShot(playlist.radioButton01);
    public void PlayRadioButton02SFX() => sfxSource.PlayOneShot(playlist.radioButton02);
    public void PlayRadioHighfqSFX() => sfxSource.PlayOneShot(playlist.radioPlayingHighFQ);
    public void PlayRadioLowfqSFX() => sfxSource.PlayOneShot(playlist.radioPlayingLowFQ);
    public void PlayRadioOffKeyfqSFX() => sfxSource.PlayOneShot(playlist.radioPlayingOffKeyFQ);

        // INSIDE SFX
    public void PlayWindowHitSFX() => sfxSource.PlayOneShot(playlist.windowHit);
    public void PlayWindowKnockSFX() => sfxSource.PlayOneShot(playlist.windowKnock);
    public void PlayWindowSingleTapSFX() => sfxSource.PlayOneShot(playlist.windowSingleTap);
    public void PlayWindowTapSFX() => sfxSource.PlayOneShot(playlist.windowTap);

        // OUTSIDE SFX
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

    // private on purpose: let the AudioManager decide which SFX source plays the audio
    private void PlayDialogueSFX(SFX soundEffect, AudioSource source) {
        switch (soundEffect)
        {
            case SFX.Static1: source.PlayOneShot(playlist.radioPlayingLowFQ); break;
            case SFX.Static2: source.PlayOneShot(playlist.radioPlayingHighFQ); break;
            case SFX.Static3: source.PlayOneShot(playlist.radioPlayingOffKeyFQ); break;
            case SFX.Flashlight1: source.PlayOneShot(playlist.flashlightOn); break;
            case SFX.Flashlight2: source.PlayOneShot(playlist.flashlightOff); break;
            case SFX.Flashlight3: source.PlayOneShot(playlist.flashlightRattle); break;
            case SFX.Flashlight4: source.PlayOneShot(playlist.flashlightHit); break;
            case SFX.WindowTap: source.PlayOneShot(playlist.windowSingleTap); break;
            case SFX.WindowHit: source.PlayOneShot(playlist.windowHit); break;
            case SFX.WindowKnock: source.PlayOneShot(playlist.windowKnock); break;
            case SFX.WindowTwotaps: source.PlayOneShot(playlist.windowTap); break;
        }
    }
    //we use these in the other classes to pass an enum to play a sound on the normal SFX channel
    public void PlayDialogueSFX(SFX soundEffect)
    {
        PlayDialogueSFX(soundEffect, sfxSource);
    }
    //we use these in the other classes to pass an enum to play a sound on the radio-static-altered SFX channel
    public void PlayRadioDialogueSFX(SFX soundEffect)
    {
        PlayDialogueSFX(soundEffect, radioSfxSource);
    }

}
