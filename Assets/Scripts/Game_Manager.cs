using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager _instance;
    public HexGrids hexGrid;
    const int point = 1;
    public List<Color> totalColors;

    public int[] levelCaps;

    private int points=0;
    private int currentLevel=2;

    private int totalNumberOfCells=0;
    private int availableNeighbourNumber=0;

    private bool isGameOn=false;


    // Start is called before the first frame update
    void Awake()
    {
        if(_instance==null)
        {
            _instance=this;
        }
        
    }

    public void AddPoints()
    {
        points+=(point * currentLevel+1);
        UI_Manager._instance.UpdatePoints(points);
        CheckLevel();
        SaveManager._instance.AdjustPoints(points);
    }

    // Checks the player points and increase the level accordingly
    void CheckLevel() 
    {
        int levelIndex = 0;
        for(int i = 0 ; i < levelCaps.Length;i++)
        {
            if(levelCaps[i] < points)
            {
                levelIndex=i;
            }
        }
        currentLevel=levelIndex;
    }

    public Color GetColor()
    {
        return totalColors[Random.Range(0,currentLevel+1)];
    }

    public void StartGame()
    {
        isGameOn=true;
        hexGrid.GenerateGrid();
        
    }

    public void QuitGame()
    {
        
        Application.Quit();
    }

    // Calculates the total number of cells and resets the available neighbours to 0
    public void SetRowsCols(int rows, int cols)
    {
        availableNeighbourNumber=0;
        totalNumberOfCells= rows * cols;
    }
    public void CheckNeighbourAvailability(bool isAvailable)
    {
        if(isAvailable)
        {
            availableNeighbourNumber++;
        }
        else
        {
            availableNeighbourNumber--;
        }

        if(availableNeighbourNumber <= (-1*totalNumberOfCells))
        {
            Debug.Log("GAME END");
        }
    }
}
