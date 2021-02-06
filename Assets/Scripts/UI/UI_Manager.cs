using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
public class UI_Manager : MonoBehaviour
{
    public static UI_Manager _instance;
    public TextMeshProUGUI pointsText;

    private int playerPoint;
    private int currentPoint;

    public CanvasGroup[] menus;

/// <summary>
/// UI elements in the main menu
/// </summary>
    public UI_Animations[] mainMenuItems;
    public UI_LanguageSelection _ui_LangunageSelection;
    
    public UnityEvent mainMenuHideEvent;

    public float minTime=0.5f;
    public float maxTime =1.5f;

    // Start is called before the first frame update
    void Awake()
    {
        if(!_instance)
        {
            _instance=this;
        }
        
    }

    void Start()
    {
        ShowCanvasGroup(0);
    }


    /// <summary>
    /// Updates Points Text in the UI by sending the value to the UI_Points
    /// </summary>
    /// <param name="newPoint"></param>
    public void UpdatePoints(int newPoint)
    {
        //pointsText.text = newPoint.ToString();
        UI_Points._instance.AddPoints(newPoint);
    }

    /// <summary>
    /// Shows selected id canvas group in the UI and hides others instantly
    /// </summary>
    /// <param name="canvasID">ID of the canvas</param> 
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

    public IEnumerator ShowCanvasGroupWait(int canvasID)
    {
        yield return new WaitForSeconds(maxTime);
        ShowCanvasGroup(canvasID);
    }

    public void ShowCanvasGroupCoroutine(int canvasID)
    {
        IEnumerator coroutine = ShowCanvasGroupWait(canvasID);
        StartCoroutine(coroutine);
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
        _ui_LangunageSelection.HideLanguageButtons();
    }

    public void HideMainMenuItems()
    {
        for (int i = 0; i < mainMenuItems.Length; i++)
        {
            mainMenuItems[i].HideItemScaleDown(minTime,maxTime);
        }

        mainMenuHideEvent.Invoke();
    }

    public float GetMinTime()
    {
        return minTime;
    }

    public float GetMaxTime()
    {
        return maxTime;
    }
}
