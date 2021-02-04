using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Options_Manager : MonoBehaviour
{
    public CanvasGroup optionsCG;
    public GetInput _getInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowHideOptions()
    {
        if(optionsCG.alpha==0f)
        {
            ShowOptions();
        }
        else
        {
            HideOptions();
        }
    }

    void ShowOptions()
    {
        optionsCG.alpha=1f;
        optionsCG.blocksRaycasts=true;
        optionsCG.interactable=true;
        optionsCG.ignoreParentGroups=true;
    }

    void HideOptions()
    {
        optionsCG.alpha=0f;
        optionsCG.blocksRaycasts=false;
        optionsCG.interactable=false;
        optionsCG.ignoreParentGroups=false;
    }

/// <summary>
/// 1 for single click ,2 for double click, any other number will select single click
/// </summary>
/// <param name="clickMode"></param>
    public void SelectClickMode(int clickMode)
    {
        if(clickMode == 1)
        {
            _getInput.inputType = GetInput.InputType.Single_Click;
            
        }
        else if(clickMode == 2)
        {
            _getInput.inputType = GetInput.InputType.Double_Click;
        }
        else
        {
            _getInput.inputType = GetInput.InputType.Single_Click;
        }
        SaveManager._instance.AdjustInputType(_getInput.inputType);
        HideOptions();
    }
   
}
