using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class HexCell : MonoBehaviour
{
    //public HexCoordinates coordinates;

	public Color color;

    public List<GameObject> neighbours;
    private bool isCellDestroyed=false;


    

    public void AddNeighbour(GameObject go)
    {
        if(neighbours==null)
        {
            neighbours = new List<GameObject>();
        }

        if(!neighbours.Contains(go))
        {
            neighbours.Add(go);
            go.GetComponent<HexCell>().AddNeighbour(this.gameObject);
        }
       
    }

    public void Destroy()
    {
        isCellDestroyed=true;
        iTween.ScaleTo(this.gameObject,Vector3.zero,0.5f);
        //Game_Manager._instance.AddPoints();
        SoundManager._instance.PlayEffect();
        Invoke("Respawn",2.5f);
    }

    public void SpawnHexCell(Vector3 scale, Color newColor)
    {
        color = newColor;
        this.gameObject.GetComponent<Renderer>().material.color = color;
        iTween.ScaleTo(this.gameObject,scale,0.5f);
        Game_Manager._instance.CheckNeighbourAvailability(CheckNeighbourColor());
    }
    public void Respawn()
    {
        Color newColor =  Game_Manager._instance.GetColor();
        this.gameObject.GetComponent<Renderer>().material.color = newColor;
        color = newColor;
        iTween.ScaleTo(this.gameObject,new Vector3(0.42f, 0.42f, 0.42f),0.5f);
        isCellDestroyed=false;
        
    }

    public void CheckNeighbours()
    {
        foreach (GameObject neighbour in neighbours)
        {
            neighbour.GetComponent<HexCell>().CheckColor(color);
        }
    }

    public void CheckColor(Color colorCheck)
    {
        if(colorCheck == color && !isCellDestroyed)
        {
            Game_Manager._instance.AddNeighbourCells(this);
            Destroy();
            CheckNeighbours();
        }
        
    }

    public void StartCheckingNeighbours()
    {
        foreach (GameObject neighbour in neighbours)
        {
            neighbour.GetComponent<HexCell>().CheckColor(color);
            Game_Manager._instance.AddNeighbourCells(this);
            Destroy();
            isCellDestroyed=true;
            
        }
        Game_Manager._instance.CalculatePoints();
    }

    public bool CheckNeighbourColor()
    {
        for(int i=0;i<neighbours.Count;i++)
        {
            if(neighbours[i].gameObject.GetComponent<HexCell>().color == this.color)
            {
                return true;            
            }
        }
        return false;
    }
}
