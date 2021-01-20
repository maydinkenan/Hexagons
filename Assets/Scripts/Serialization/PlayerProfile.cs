using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProfile 
{
   public int highScore;
   

   public PlayerProfile()
   {
       highScore=0;
       
   }

   /// <summary>
   /// Checks if the new score is higher than the previous highscore and returns true if it is
   /// </summary>
   /// <param name="newHighScore"></param>
   /// <returns></returns>
   public bool UpdateHighScore(int newHighScore)
   {
       if(highScore<newHighScore)
       {
           highScore = newHighScore;
           return true;
       }
       
       return false;
   }


   //public List<HexCell> hexagons;

   
}
