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
    public Color[] colors;
    public List<List<GameObject>> rowList;
    void Start () 
    {
    //GenerateGrid();    
        
    }

    public void GenerateGrid()
    {
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
                Color tempColor = GetRandomColor();
                go.GetComponent<Renderer>().material.color=tempColor;
                go.GetComponent<HexCell>().color = tempColor;
                col.Add(go);
                if(j!=0) // Adds Neighbour to the previous Cell in the Column
                {
                    go.GetComponent<HexCell>().AddNeighbour(col[j-1]);
                }
                
                if(i>0) // Adds Neighbour to the previous Cells in the previous Row
                {
                    if(i%2==1)
                    {
                        int index = Mathf.Clamp(j-1,0,rows-1);
                        go.gameObject.GetComponent<HexCell>().AddNeighbour(rowList[i-1][index]);
                    }
                    else
                    {
                        int index = Mathf.Clamp(j+1,0,rows-1);
                        go.gameObject.GetComponent<HexCell>().AddNeighbour(rowList[i-1][index]);
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


     Color GetRandomColor()
     {
         if(colors.Length==0)
         {
             return Color.white;
         }
         else
         {
             return colors[Random.Range(0,colors.Length)];
         }
     }
 }