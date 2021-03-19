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

    public List<HexCell> neighbours;

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
        Debug.Log("Add points");
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
        if(currentLevel<levelIndex)
        {
            AnalyticsManager._instance.LevelUp(levelIndex);
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

    public void LoadGame()
    {
        isGameOn=true;
        hexGrid.GenerateGrid( SaveManager._instance.GetGameGrid() );
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

    public void CalculatePoints()
    {
        points+=(neighbours.Count+1 * (currentLevel+1));
        UI_Manager._instance.UpdatePoints(points);
        CheckLevel();
//        Debug.Log("Add points count"+neighbours.Count+" - currentlevel="+currentLevel+1);
        SaveManager._instance.AdjustPoints(points);
        /*for(int i=0;i<neighbours.Count;i++)
        {
            neighbours[i].Destroy();
        }*/
        neighbours = new List<HexCell>();
    }

    public void AddNeighbourCells(HexCell cell)
    {
        if(!neighbours.Contains(cell))
        {
            neighbours.Add(cell);
        }
    }
}
