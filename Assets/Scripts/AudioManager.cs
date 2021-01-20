using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _instance;
    public AudioSource musicSource;
    public AudioSource fxSource;
    // Start is called before the first frame update
    void Awake()
    {
        
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
/// Turns on and off the music
/// </summary>
/// <param name="newValue">True -> Music on , False -> Music off</param>
    public void AdjustMusic(bool newValue)
    {
        if(newValue)
        {
            musicSource.volume=1.0f;
        }
        else
        {
            musicSource.volume=0.0f;
        }
        SaveManager._instance.AdjustMusic(newValue);
    }
/// <summary>
/// Turns on and off the Effects sounds 
/// </summary>
/// <param name="newValue">>True -> Sound Effects on , False -> Sound Effects off</param>
    public void AdjustFX(bool newValue)
    {
        if(newValue)
        {
            fxSource.volume=1.0f;
        }
        else
        {
            fxSource.volume=0.0f;
        }

    }


    
}
