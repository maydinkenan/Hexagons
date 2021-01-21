﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_LanguageButton : MonoBehaviour
{

    public LocalisationSystem.Language buttonLanguage;
    public UI_LanguageSelection _ui_languageSelection;


   
    public void SelectLanguage()
    {
        _ui_languageSelection.ChangeLanguage(buttonLanguage);
        _ui_languageSelection.HideLanguageButtons();
    }

}