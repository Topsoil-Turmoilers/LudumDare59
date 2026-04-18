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
        if (playlist != null)
        {

        }
    }
}
