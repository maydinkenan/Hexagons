using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProfile 
{
   public int highScore;
   public List<List<HexCell>> gameGrid;
   public bool isGameSaved=false;

   public PlayerProfile()
   {
       highScore=0;
       gameGrid = new List<List<HexCell>>();
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

   
   public bool GameSaveCheck()
   {
       return isGameSaved;
   }

   public  List<List<HexCell>> GetGameGrid()
   {
       isGameSaved=false;
       return gameGrid;
   }

   public void SaveGameGrid( List<List<HexCell>> _gameGrid)
   {
       isGameSaved=true;
       gameGrid = _gameGrid;
   }


   

   
}
