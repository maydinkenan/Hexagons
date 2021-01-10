using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Game_Manager._instance.AddPoints();
        Invoke("Respawn",2.5f);
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

            Destroy();
            CheckNeighbours();
        }
    }
}
