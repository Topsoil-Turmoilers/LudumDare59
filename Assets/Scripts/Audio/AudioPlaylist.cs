using UnityEngine;

[CreateAssetMenu(fileName = "AudioPlaylist", menuName = "Scriptable Objects/AudioPlaylist")]
public class AudioPlaylist : ScriptableObject
{
    [Header("Music Tracks")]
    public AudioClip menuTheme;
    public AudioClip prologueTheme;
    public AudioClip insideTheme;
    public AudioClip outsideTheme;

    [Header("Radio SFX")]
    public AudioClip radioButton01;
    public AudioClip radioButton02;
    public AudioClip radioPlayingHighFQ;
    public AudioClip radioPlayingLowFQ;
    public AudioClip radioPlayingOffKeyFQ;

    [Header("Inside SFX")]
    public AudioClip walkInside;
    public AudioClip windowHit;
    public AudioClip windowKnock;
    public AudioClip windowSingleTap;
    public AudioClip windowTap;

    [Header("Outside SFX")]
    public AudioClip walkOutside;
    public AudioClip flashlightOn;
    public AudioClip flashlightOff;
    public AudioClip flashlightRattle;
    public AudioClip flashlightHit;
}
