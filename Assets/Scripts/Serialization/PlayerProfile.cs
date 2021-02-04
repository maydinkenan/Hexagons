using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
public class PlayerProfile 
{
    private string gameId="";

   public int highScore;
   public List<List<HexCell>> gameGrid;
   public bool isGameSaved=false;

   

   public PlayerProfile()
   {
       highScore=0;
       gameGrid = new List<List<HexCell>>();
       ResetGameID();
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


   public string GetGameID()
   {
       return gameId;
   }

    /// <summary>
    /// Resets the game id to empty
    /// </summary>
   public void ResetGameID()
   {
       gameId=string.Empty;
   }

    /// <summary>
    /// Sets a game id
    /// </summary>
   public void SetGameID()
   {
       int randomNumber = UnityEngine.Random.Range(0,100000);
       int year = DateTime.Now.Year;
       int month = DateTime.Now.Month;
       int day = DateTime.Now.Day;
       int hour = DateTime.Now.Hour;
       int minute = DateTime.Now.Minute;
       int second = DateTime.Now.Second;
       int milisecond = DateTime.Now.Millisecond;
       gameId = year.ToString() + month.ToString() + day.ToString() + 
                hour.ToString() + minute.ToString()+ second.ToString() + 
                milisecond.ToString() + randomNumber.ToString();
   }

   
}
