using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SettingsProfile 
{
    public bool musicOn;
    public bool fxOn;
    public LocalisationSystem.Language language;

    public GetInput.InputType inputType;

    public SettingsProfile()
    {
        musicOn=true;
        fxOn=true;
        language = LocalisationSystem.Language.English;
        inputType = GetInput.InputType.Single_Click;
    }
    public void AdjustMusic(bool newValue)
    {
        musicOn = newValue;
    }

    public void AdjustFX(bool newValue)
    {
        fxOn = newValue;
    }

    public void AdjustInputType(GetInput.InputType newInputType)
    {
        inputType = newInputType;
    }

}
