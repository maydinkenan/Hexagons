using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_CellsController : MonoBehaviour
{
    // Start is called before the first frame update
    public UI_Cells[] cells;
    public CanvasGroup blurLayer;

    void Start()
    {
        HideRandomCells();
    }

    public void HideAllCells()
    {
        CancelInvoke();
        for(int i = 0 ; i<cells.Length; i++)
        {
            cells[i].HidePermanent();
        }
        blurLayer.alpha=0f;
        blurLayer.blocksRaycasts=false;
        blurLayer.interactable=false;
        blurLayer.ignoreParentGroups=false;
        
    }

    public void HideRandomCells()
    {
        for(int i = 0; i<10;i++)
        {
            cells[Random.Range(0,cells.Length)].Hide();
        }
        Invoke("HideRandomCells",5f);
    }

    public void StopAnimation()
    {

    }


    void Move()
    {}
    
}
