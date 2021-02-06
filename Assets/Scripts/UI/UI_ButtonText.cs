using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_ButtonText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public void ApplyTextEffect(UI_SelectedText newValue)
    {
        text.fontStyle = newValue.fontStyles;
        text.fontSize = newValue.fontSize;
        text.color = newValue.color;
    }
}
