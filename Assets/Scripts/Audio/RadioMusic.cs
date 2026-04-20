using UnityEngine;

public class RadioMusic : MonoBehaviour
{
    [SerializeField] private AudioSource radioMusic;

    //Play the Music
    public void PlayRadioMusic()
    {
        radioMusic.Play();
    }

    //Stop the Music
    public void StopRadioMusic()
    {
        radioMusic.Stop();
    }

}
