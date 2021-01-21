using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLocaliserUI : MonoBehaviour
{
    
    TextMeshProUGUI textField;
    public string key;
    void OnEnable()
    {
        UI_LanguageSelection.LanguageChanged += LocalisedValueTrigger;
    }

    void OnDisable()
    {
        UI_LanguageSelection.LanguageChanged -= LocalisedValueTrigger;
    }
    // Start is called before the first frame update
    void Start()
    {
        LocalisedValueTrigger();
    }

    void LocalisedValueTrigger()
    {
        GetSetLocalisedValue(key);
    }

    void GetSetLocalisedValue(string _key)
    {
        textField = gameObject.GetComponent<TextMeshProUGUI>();
        string value  = LocalisationSystem.GetLocalisedValue(_key);
        textField.text = value;
        Debug.Log(" key "+key+" - value = "+value);
    }
}
