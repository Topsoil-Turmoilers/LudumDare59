using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    //Singleton Behavior
    public static OptionsManager Instance;

    //The Audio Mixer
    [SerializeField] private AudioMixer mainAudioMixer;

    //Different Volumes
    [SerializeField] private float musicVolume;
    [SerializeField] private float sfxVolume;
    [SerializeField] private float masterVolume;

    //Different Sliders
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider masterSlider;

    private void Awake()
    {
        //Singleton Behavior
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //Getting Starting Volumes
        mainAudioMixer.GetFloat("BGMVolume", out musicVolume);
        mainAudioMixer.GetFloat("SFXVolume", out sfxVolume);
        mainAudioMixer.GetFloat("MasterVolume", out masterVolume);

        //Setting Sliders to Starting Volumes
        musicSlider.value = DecibelToFloat(musicVolume) * 100;
        sfxSlider.value = DecibelToFloat(sfxVolume) * 100;
        masterSlider.value = DecibelToFloat(masterVolume) * 100;
    }

    //Changing Volumes When Sliders Move
    public void ChangeMusicVolume(System.Single volume)
    {
        //Changing Music Volume to Slider Setting
        volume = volume / 100; //Because to do the math it has to be a 0 to 100 range instead of 0 to 1
        volume = FloatToDB(volume);
        musicVolume = volume;
        mainAudioMixer.SetFloat("BGMVolume", musicVolume);
    }

    public void ChangeSFXVolume(System.Single volume)
    {
        //Changing SFX Volume to Slider Setting
        volume = volume / 100;
        volume = FloatToDB(volume);
        sfxVolume = volume;
        mainAudioMixer.SetFloat("SFXVolume", sfxVolume);
    }

    public void ChangeMasterVolume(System.Single volume)
    {
        //Changing Master Volume to Slider Setting
        volume = volume / 100;
        volume = FloatToDB(volume);
        masterVolume = volume;
        mainAudioMixer.SetFloat("MasterVolume", masterVolume);
    }

    //Helper Functions
    private float FloatToDB(float volume)
    {
        if (volume > 0.00001) //Checking if it is 0 (because can't do log with 0) by comparing to EPSILON
        {
            volume = 20.0f * Mathf.Log10(volume); //20, not 10 because this is amplitude not power
        }
        else //If it is 0, set it to the decibel floor
        {
            volume = -144.0f;
        }

        return volume;
    }

    private float DecibelToFloat(float decibel)
    {
        decibel = Mathf.Pow(10.0f, decibel / 20.0f); //literally just undoes the other function
        return decibel;
    }
}
