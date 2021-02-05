using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Options_Manager : MonoBehaviour
{
    public static UI_Options_Manager _instance;
    public CanvasGroup optionsCG;
    public GetInput _getInput;

    [Space(10)]
    public UI_SelectedText selectedText;
    public UI_SelectedText unSelectedText;

    public UI_ButtonText singleClickButton;
    public UI_ButtonText doubleClickButton;
    

    
    void Awake()
    {
        if(!_instance)
        {
            _instance = this;
        }
    }

    
    /// <summary>
    /// If the options buttons are on, hides them. If they are off shows them
    /// Decision is depending on the Option Buttons Canvas Group alpha value
    /// </summary>
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
    /// <summary>
    /// Shows the options button and Hides Language Buttons
    /// </summary>
    void ShowOptions()
    {
        optionsCG.alpha=1f;
        optionsCG.blocksRaycasts=true;
        optionsCG.interactable=true;
        optionsCG.ignoreParentGroups=true;

        UI_LanguageSelection._instance.HideLanguageButtons();
    }
    /// <summary>
    /// Hides the Option Buttons
    /// </summary>
    public void HideOptions()
    {
        optionsCG.alpha=0f;
        optionsCG.blocksRaycasts=false;
        optionsCG.interactable=false;
        optionsCG.ignoreParentGroups=false;

        
    }

/// <summary>
/// 
/// 1 for single click ,2 for double click, any other number will select single click
/// </summary>
/// <param name="clickMode"></param>
    public void SelectClickMode(int clickMode)
    {
        if(clickMode == 1)
        {
            _getInput.inputType = GetInput.InputType.Single_Click;
            singleClickButton.Apply(selectedText);
            doubleClickButton.Apply(unSelectedText);
        }
        else if(clickMode == 2)
        {
            _getInput.inputType = GetInput.InputType.Double_Click;
            singleClickButton.Apply(unSelectedText);
            doubleClickButton.Apply(selectedText);
        }
        else
        {
            _getInput.inputType = GetInput.InputType.Single_Click;
            singleClickButton.Apply(selectedText);
            doubleClickButton.Apply(unSelectedText);
        }
        SaveManager._instance.AdjustInputType(_getInput.inputType);
        HideOptions();
    }
   
}
