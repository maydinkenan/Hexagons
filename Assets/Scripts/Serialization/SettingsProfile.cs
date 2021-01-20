using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SettingsProfile 
{
    public bool musicOn;
    public bool fxOn;
    public int languageID;

    public SettingsProfile()
    {
        musicOn=true;
        fxOn=true;
        languageID=0;
    }
    public void AdjustMusic(bool newValue)
    {
        musicOn = newValue;
    }

    public void AdjustFX(bool newValue)
    {
        fxOn = newValue;
    }

}
