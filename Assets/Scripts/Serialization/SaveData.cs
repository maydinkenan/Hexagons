using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData 
{

    public PlayerProfile profile; 
   public SettingsProfile settings;

   public SaveData()
   {
       profile = new PlayerProfile();
       settings = new SettingsProfile();
   }
}
