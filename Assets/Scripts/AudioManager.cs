using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    public static AudioManager _instance;
    public AudioSource musicSource;
    public AudioSource fxSource;


    [SerializeField] float volumeMultiplier = 30f;
    [Space(10)]
    [Header("Music Volume")]
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] string musicVolumeParameter = "musicVolume";
    

    [Space(10)]
    [Header("Sound FX")]
    [SerializeField] Slider soundfxVolumeSlider;
    [SerializeField] string soundfxVolumeParameter = "soundfxVolume";
    
    // Start is called before the first frame update
    void Awake()
    {
        musicVolumeSlider.onValueChanged.AddListener(HandleMusicSliderValueChanged);
        soundfxVolumeSlider.onValueChanged.AddListener(HandleSoundFxSliderValueChanged);

        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        if(!_instance)
        {
            _instance=this;
        }
        

        DontDestroyOnLoad(this.gameObject);
    }
/// <summary>
/// Sets the musicvalue on the slider
/// </summary>
/// <param name="newValue"></param>
    public void AdjustMusic(float newValue)
    {
        HandleMusicSliderValueChanged(newValue);
        SaveManager._instance.AdjustMusic(newValue);
    }
/// <summary>
/// Sets the fx volume value on the slider
/// </summary>
/// <param name="newValue">></param>
    public void AdjustFX(float newValue)
    {
        HandleSoundFxSliderValueChanged(newValue);

    }


    public void HandleMusicSliderValueChanged(float value)
    {
        
        _mixer.SetFloat(musicVolumeParameter,Mathf.Log10(value) * volumeMultiplier);
        SaveManager._instance.AdjustMusic(value);
    }

    public void HandleSoundFxSliderValueChanged(float value)
    {
        _mixer.SetFloat(soundfxVolumeParameter,Mathf.Log10(value) * volumeMultiplier);
        SaveManager._instance.AdjustFX(value);
    }
    

    
}
