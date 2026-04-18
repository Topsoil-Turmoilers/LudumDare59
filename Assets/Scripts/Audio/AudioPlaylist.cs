using UnityEngine;

[CreateAssetMenu(fileName = "AudioPlaylist", menuName = "Scriptable Objects/AudioPlaylist")]
public class AudioPlaylist : ScriptableObject
{
    [Header("Music Tracks")]
    public AudioClip menuTheme;
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
    public AudioClip windowHit01;
    public AudioClip windowHit02;
    public AudioClip windowKnock;
    public AudioClip windowSingleTap;
    public AudioClip windowTap01;
    public AudioClip windowTap02;

    [Header("Outside SFX")]
    public AudioClip walkOutside;
}
