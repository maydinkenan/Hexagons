using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_ChangeImage : MonoBehaviour
{
    bool onOff=true;
    public Sprite onSprite;
    public Sprite offSprite;
    public Image audioImage;

    public AudioSource audioSource;

    void Start()
    {
        CheckAudioSource();
        Debug.Log("Check Image start");
    }
    public void ChangeImage()
    {
        CheckAudioSource();
        onOff = !onOff;
        if(onOff)
        {
            audioImage.sprite = onSprite;
            
            audioSource.volume=1f;
        }
        else
        {
            audioImage.sprite = offSprite;
            audioSource.volume=0f;
        }
    }


    void CheckAudioSource()
    {
        if(!audioSource)
        {
            audioSource =  GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();
            if(audioSource.volume==0f)
            {
                onOff=false;
                audioImage.sprite = offSprite;
            }
            else
            {
                onOff=true;
                audioImage.sprite = onSprite;
            }
        }
    }
}

