using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_LanguageSelection : MonoBehaviour
{
    public Image selectedLanguageImage;
    public Sprite[] languageSprites;
    public CanvasGroup languageButtons;

    public delegate void ChangeLanguageAction();
    public static event ChangeLanguageAction LanguageChanged;

    public static UI_LanguageSelection _instance;
    
    void Awake()
    {
        if(!_instance)
        {
            _instance=this;
        }
    }
    void Start()
    {
        
        HideLanguageButtons();
    }

    /// <summary>
    /// Loads new language settings and saves
    /// </summary>
    /// <param name="newLanguage"></param>
    public void ChangeLanguage(LocalisationSystem.Language newLanguage)
    {
        switch(newLanguage)
        {
            case LocalisationSystem.Language.English:
                selectedLanguageImage.sprite = languageSprites[0];
                break;
            case LocalisationSystem.Language.Turkish:
                selectedLanguageImage.sprite = languageSprites[1];
                break;
            case LocalisationSystem.Language.German:
                selectedLanguageImage.sprite = languageSprites[2];
                break;
            case LocalisationSystem.Language.Dutch:
                selectedLanguageImage.sprite = languageSprites[3];
                break;
            case LocalisationSystem.Language.Spanish:
                selectedLanguageImage.sprite = languageSprites[4];
                break;
            case LocalisationSystem.Language.French:
                selectedLanguageImage.sprite = languageSprites[5];
                break;
            default:
                selectedLanguageImage.sprite = languageSprites[0];
                break;
        }
        Debug.Log("Change Language "+newLanguage);
        SaveManager._instance.AdjustLanguage(newLanguage);
        HideLanguageButtons();
        
        LanguageChanged();//Event Trigger
       //UpdateLanguage();
    }

    /// <summary>
    /// Loads new language settings and do not save
    /// </summary>
    /// <param name="newLanguage"></param>
    public void LoadLanguage(LocalisationSystem.Language newLanguage)
    {
       switch(newLanguage)
        {
            case LocalisationSystem.Language.English:
                selectedLanguageImage.sprite = languageSprites[0];
                break;
            case LocalisationSystem.Language.Turkish:
                selectedLanguageImage.sprite = languageSprites[1];
                break;
            case LocalisationSystem.Language.German:
                selectedLanguageImage.sprite = languageSprites[2];
                break;
            case LocalisationSystem.Language.Dutch:
                selectedLanguageImage.sprite = languageSprites[3];
                break;
            case LocalisationSystem.Language.Spanish:
                selectedLanguageImage.sprite = languageSprites[4];
                break;
            case LocalisationSystem.Language.French:
                selectedLanguageImage.sprite = languageSprites[5];
                break;
            default:
                selectedLanguageImage.sprite = languageSprites[0];
                break;
        }
        Debug.Log("Load Language "+newLanguage);
        HideLanguageButtons();
        
        LanguageChanged();//Event Trigger 
    }


    public void ShowHideLanguage()
    {
        if(languageButtons.alpha==1f)
        {
            HideLanguageButtons();
        }
        else
        {
            ShowLanguageButtons();
            UI_Options_Manager._instance.ShowOptionsMenu(2);
        }
    }
    

    public void UpdateLanguage()
    {
        
    }

    public void ShowLanguageButtons()
    {
        languageButtons.alpha=1f;
        languageButtons.blocksRaycasts=true;
        languageButtons.interactable=true;
        languageButtons.ignoreParentGroups=true;

        UI_Click_Options_Manager._instance.HideOptions();
    }

    public void HideLanguageButtons()
    {
        languageButtons.alpha=0f;
        languageButtons.blocksRaycasts=false;
        languageButtons.interactable=false;
        languageButtons.ignoreParentGroups=false;
    }
}
