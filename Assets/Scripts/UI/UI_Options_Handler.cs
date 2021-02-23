using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class UI_Options_Handler : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup options_menu;

    [SerializeField]
    private UnityEvent showStartEvent;
    [SerializeField]
    private UnityEvent hideStartEvent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void HideOptionMenu()
    {
        if(hideStartEvent!=null)
        {
            hideStartEvent.Invoke();
        }

        options_menu.alpha=0f;
        options_menu.blocksRaycasts=false;
        options_menu.ignoreParentGroups=false;
        options_menu.interactable=false;
    }

    public void ShowOptionsMenu()
    {
        if(showStartEvent!=null)
        {
            showStartEvent.Invoke();
        }
        options_menu.alpha=1f;
        options_menu.blocksRaycasts=true;
        options_menu.ignoreParentGroups=true;
        options_menu.interactable=true;
    }
}
