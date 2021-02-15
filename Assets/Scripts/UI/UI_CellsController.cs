using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_CellsController : MonoBehaviour
{
    public static UI_CellsController _instance;
    public UI_Cells[] cells;
    public CanvasGroup blurLayer;

    private float lastUpdateTime=0f;
    private float updateRate=5f;
    private bool canHideRandomCells=true;

    public UI_CellMovement _ui_cell_movement;

    void Awake()
    {
        if(!_instance)
        {
            _instance = this;
        }
    }


    void Update()
    {
        HideRandomCellsUpdate();
    }
/// <summary>
/// Hides all cells, stops movement animation and random hiding animations, also hides the blur layer
/// </summary>
    public void HideAllCells()
    {
        canHideRandomCells=false;
        _ui_cell_movement.StopMovement();
       
        // for(int i = 0 ; i<cells.Length; i++)
        // {
        //     cells[i].HidePermanent();
        // }

        StartCoroutine(HideAllCellsCoroutine());
        blurLayer.alpha=0f;
        blurLayer.blocksRaycasts=false;
        blurLayer.interactable=false;
        blurLayer.ignoreParentGroups=false;
        
    }

    
    public void HideRandomCellsUpdate()
    {
        if(canHideRandomCells)
        {
            if(Time.time>=lastUpdateTime)
            {
                lastUpdateTime = Time.time + updateRate;
                for(int i = 0; i < 10; i++)
                {
                    cells[Random.Range(0,cells.Length)].Hide();
                }
            }
        }
    }

    private IEnumerator HideAllCellsCoroutine()
    {
        int counter =0;
        float waitTime = 0.001f;
        while (counter < cells.Length)
        {
            yield return new WaitForSeconds(waitTime);
            cells[counter].HidePermanent();

            
            counter++;
        }
    }



    
}
