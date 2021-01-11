using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_Manager : MonoBehaviour
{
    public static UI_Manager _instance;
    public TextMeshProUGUI pointsText;

    private int playerPoint;
    private int currentPoint;

    public CanvasGroup[] menus;
    // Start is called before the first frame update
    void Start()
    {
        if(!_instance)
        {
            _instance=this;
        }
        ShowCanvasGroup(0);
    }



    public void UpdatePoints(int newPoint)
    {
        pointsText.text = newPoint.ToString();
    }

    public void ShowCanvasGroup(int canvasID)
    {
        for(int i = 0; i<menus.Length;i++)
        {
            if(i==canvasID)
            {
                ShowCanvas(menus[i]);
            }
            else
            {
                HideCanvas(menus[i]);
            }
        }
    }

    void ShowCanvas(CanvasGroup cg)
    {
        cg.interactable=true;
        cg.ignoreParentGroups=true;
        cg.blocksRaycasts=true;
        cg.alpha=1f;
    }

    void HideCanvas(CanvasGroup cg)
    {
        cg.interactable=false;
        cg.ignoreParentGroups=false;
        cg.blocksRaycasts=false;
        cg.alpha=0f;
    }
}
