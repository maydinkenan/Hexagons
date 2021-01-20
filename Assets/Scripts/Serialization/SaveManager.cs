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
        PlayerProfile profile = new PlayerProfile();
        SettingsProfile settings = new SettingsProfile();
        currrentSaveData = new SaveData();
        profile.highScore = 0;
        currrentSaveData.profile = profile;

        SerializationManager.Save(saveText,currrentSaveData);
    }

    



    public void OnLoadState()
    {
        string path = Application.persistentDataPath + "/saves/" + saveText + ".save";
        currrentSaveData = (SaveData)SerializationManager.Load(path);

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
}
