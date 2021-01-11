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
    // Start is called before the first frame update
    void Start()
    {
        if(_instance==null)
        {
            _instance=this;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints()
    {
        points+=(point * currentLevel-1);
        UI_Manager._instance.UpdatePoints(points);
    }

    void CheckLevel()
    {
        int levelIndex = 0;
        for(int i = 0 ; i < levelCaps.Length;i++)
        {
            if(levelCaps[i] > points)
            {
                levelIndex=i;
                break;
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
        hexGrid.GenerateGrid();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    

}
