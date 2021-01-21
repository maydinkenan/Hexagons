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

    public static UI_ChangeImage _audioChangeImageInstance;

    void Awake()
    {
        if(!_audioChangeImageInstance)
        {
            _audioChangeImageInstance=this;
        }
    }


    public void AdjustImage()
    {
        onOff = !onOff;
        ChangeImage(onOff);
    }


    public void ChangeImage(bool newValue)
    {
        
        onOff = newValue;
        if(onOff)
        {
            audioImage.sprite = onSprite;
        }
        else
        {
            audioImage.sprite = offSprite;  
        }

        AudioManager._instance.AdjustMusic(onOff);
    }


    
}

