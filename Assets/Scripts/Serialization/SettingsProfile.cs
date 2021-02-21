using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SettingsProfile 
{
    public float musicVolume;
    public float fxVolume;
    public LocalisationSystem.Language language;

    public GetInput.InputType inputType;

    private const float defaultVolume=0.7f;

    public SettingsProfile()
    {
        musicVolume=defaultVolume;
        fxVolume=defaultVolume;
        language = LocalisationSystem.Language.English;
        inputType = GetInput.InputType.Single_Click;
    }
    public void AdjustMusic(float newValue)
    {
        musicVolume = newValue;
    }

    public void AdjustFX(float newValue)
    {
        fxVolume = newValue;
    }

    public void AdjustInputType(GetInput.InputType newInputType)
    {
        inputType = newInputType;
    }

}
