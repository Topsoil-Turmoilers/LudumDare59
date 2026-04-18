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
        //Safety check
        if (playlist != null && playlist.menuTheme != null)
        {
            PlayMenuMusic();
        }
    }

    // MUSIC ===========================================================
    public void PlayMenuMusic() => PlayMusic(playlist.menuTheme);
    public void PlayInsideMusic() => PlayMusic(playlist.insideTheme);
    public void PlayOutsideMusic() => PlayMusic(playlist.outsideTheme);

    // SFX =============================================================

    public void PlayWalkInsideSFX() => sfxSource.PlayOneShot(playlist.walkInside);
    public void PlayWalkOutsideSFX() => sfxSource.PlayOneShot(playlist.walkOutside);

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
