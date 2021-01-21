using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager _instance;

    public string saveText="hexagons";
    public SaveData currrentSaveData;
    // Start is called before the first frame update
    void Awake()
    {
       if(!_instance)
       {
           _instance=this;
       }
    }

    void Start()
    {
        OnLoadState();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            OnSaveState();
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
            OnLoadState();
        }
    }

    public void OnSaveState()
    {

        SerializationManager.Save(saveText,currrentSaveData);
    }

    



    public void OnLoadState()
    {
        string path = Application.persistentDataPath + "/saves/" + saveText + ".save";
        currrentSaveData = new SaveData();
        currrentSaveData = (SaveData)SerializationManager.Load(path);
        
        LocalisationSystem.language = currrentSaveData.settings.language;
        UI_LanguageSelection._instance.ChangeLanguage(LocalisationSystem.language);

        LoadMusic(currrentSaveData.settings.musicOn);


    }

    public void AdjustMusic(bool newValue)
    {
        if(currrentSaveData==null)
        {
            currrentSaveData = new SaveData();

        }
        
        currrentSaveData.settings.AdjustMusic(newValue);

    }
    

    public void LoadMusic(bool musicValue)
    {
        AudioManager._instance.AdjustMusic(musicValue);
        UI_ChangeImage._audioChangeImageInstance.ChangeImage(musicValue);
    }
    public void LoadFX(bool fxValue)
    {
        AudioManager._instance.AdjustFX(fxValue);

    }

    public void AdjustFX(bool newvalue)
    {
         if(currrentSaveData==null)
        {
            currrentSaveData = new SaveData();

        }

        currrentSaveData.settings.AdjustFX(newvalue);
    }
    /// <summary>
    /// Returns True if the newPoints is higher than the previous one
    /// </summary>
    /// <param name="newPoints"></param>
    /// <returns></returns>
    public bool AdjustPoints(int newPoints)
    {
        return currrentSaveData.profile.UpdateHighScore(newPoints);
    }

    public void AdjustLanguage(LocalisationSystem.Language newLanguage)
    {
        currrentSaveData.settings.language = newLanguage;
        LocalisationSystem.language = newLanguage;
        OnSaveState();
    }
}
