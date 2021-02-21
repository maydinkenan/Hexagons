 using UnityEngine;
 using System.Collections;
 using System.Collections.Generic;
 public class HexGrids : MonoBehaviour {

    public GameObject prefab;
    public Vector3 v3Center = Vector3.zero;
    public float objDistance =  0.75f;  // Distance apart objects are apart on a row
    public int rows = 12;
    public int cols = 12;
    
    private float rowDist;
    private float rowStart;
    private Vector3 v3Pos; 
    private Vector3 v3Scale = new Vector3(0.42f, 0.42f, 0.42f);
    public List<List<GameObject>> rowList;
    
    public List<List<HexCell>> hexgrid;

/// <summary>
/// Generates a random new game grid and saves the it to the profile
/// </summary>
    public void GenerateGrid()
    {
        Game_Manager._instance.SetRowsCols(rows,cols);

        rowList = new List<List<GameObject>>();
        // Distance the rows are apart Sqrt(objDist^2 - (objDist/2)^2)
        float fT = ((objDistance * objDistance) - ((objDistance * objDistance * 0.25f)));
        rowDist  = Mathf.Sqrt ((objDistance * objDistance) - ((objDistance * objDistance * 0.25f)));
        rowStart = -(cols * objDistance / 2.0f - 0.25f * objDistance);
        v3Pos    = new Vector3(rowStart, rows * rowDist / 2.0f, 0.0f); 
        hexgrid = new List<List<HexCell>>();
        for (int i = 0; i < rows; i++) 
        {
            if ((i % 2) == 1)
            {
                v3Pos.x -= objDistance / 2.0f;
            }
                    
            List<HexCell> hexCol = new List<HexCell>();
            List<GameObject> col = new List<GameObject>();
            for (int j = 0; j < cols; j++) 
            {
                GameObject go =Instantiate(prefab);
                go.transform.position = v3Pos + v3Center;
                go.transform.localScale = v3Scale;
                go.transform.parent=this.transform;
                go.transform.name+= " "+i+" - "+j;
                v3Pos.x += objDistance;         
                Color cellColor = Game_Manager._instance.GetColor();
                HexCell hc = go.GetComponent<HexCell>();

                hexCol.Add(hc);

                hc.SpawnHexCell(v3Scale,cellColor);
                col.Add(go);
                if(j!=0) // Adds Neighbour to the previous Cell in the Column
                {
                    hc.AddNeighbour(col[j-1]);
                }
                
                if(i>0) // Adds Neighbour to the previous Cells in the previous Row
                {
                    if(i%2==1)
                    {
                        int index = Mathf.Clamp(j-1,0,rows-1);
                        hc.AddNeighbour(rowList[i-1][index]);
                    }
                    else
                    {
                        int index = Mathf.Clamp(j+1,0,cols-1);
                        hc.AddNeighbour(rowList[i-1][index]);
                    }
                    go.gameObject.GetComponent<HexCell>().AddNeighbour(rowList[i-1][j]);
                }

                iTween.ScaleFrom(go.gameObject,Vector3.zero,Random.Range(0.1f,1f));
            }
            hexgrid.Add(hexCol);
            rowList.Add(col);
            v3Pos.x = rowStart;
            v3Pos.y -= rowDist;
        }

        //SaveManager._instance.currrentSaveData.profile.SaveGameGrid(hexgrid);
    }

    public void GenerateGrid(List<List<HexCell>> newGrid)
    {
        Game_Manager._instance.SetRowsCols(rows,cols);

        rowList = new List<List<GameObject>>();
        // Distance the rows are apart Sqrt(objDist^2 - (objDist/2)^2)
        float fT = ((objDistance * objDistance) - ((objDistance * objDistance * 0.25f)));
        rowDist  = Mathf.Sqrt ((objDistance * objDistance) - ((objDistance * objDistance * 0.25f)));
        rowStart = -(cols * objDistance / 2.0f - 0.25f * objDistance);
        v3Pos    = new Vector3(rowStart, rows * rowDist / 2.0f, 0.0f); 
        
        for (int i = 0; i < rows; i++) 
        {
            if ((i % 2) == 1)
            {
                v3Pos.x -= objDistance / 2.0f;
            }
                    
            List<GameObject> col = new List<GameObject>();
            for (int j = 0; j < cols; j++) 
            {
                GameObject go =Instantiate(prefab);
                go.transform.position = v3Pos + v3Center;
                go.transform.localScale = v3Scale;
                go.transform.parent=this.transform;
                go.transform.name+= " "+i+" - "+j;
                v3Pos.x += objDistance;         
                Color cellColor = Game_Manager._instance.GetColor();
                HexCell hc = go.GetComponent<HexCell>();

                hc.SpawnHexCell(v3Scale,cellColor);
                col.Add(go);
                if(j!=0) // Adds Neighbour to the previous Cell in the Column
                {
                    hc.AddNeighbour(col[j-1]);
                }
                
                if(i>0) // Adds Neighbour to the previous Cells in the previous Row
                {
                    if(i%2==1)
                    {
                        int index = Mathf.Clamp(j-1,0,rows-1);
                        hc.AddNeighbour(rowList[i-1][index]);
                    }
                    else
                    {
                        int index = Mathf.Clamp(j+1,0,cols-1);
                        hc.AddNeighbour(rowList[i-1][index]);
                    }
                    go.gameObject.GetComponent<HexCell>().AddNeighbour(rowList[i-1][j]);
                }

                iTween.ScaleFrom(go.gameObject,Vector3.zero,Random.Range(0.1f,1f));
            }
            rowList.Add(col);
            v3Pos.x = rowStart;
            v3Pos.y -= rowDist;
        }
    }


     bool CheckNeighbourAvailability()
     {
        for(int i = 0; i<rows ; i++)
        {
            for(int j =0 ; j<cols ; j++)
            {
                if(rowList[i][j].gameObject.GetComponent<HexCell>().CheckNeighbourColor())
                {
                    return true;
                }
            }
        }
        return false;
     }
 }