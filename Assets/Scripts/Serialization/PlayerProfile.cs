using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProfile 
{
   public bool musicOnOff;
   public bool fxOnOff;
   public int highScore;
   
   public void UpdateHighScore(int newHighScore)
   {
       if(highScore<newHighScore)
       {
           highScore = newHighScore;
       }
   }


   //public List<HexCell> hexagons;

   
}
