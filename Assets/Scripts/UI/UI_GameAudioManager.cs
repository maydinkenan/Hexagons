using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_GameAudioManager : MonoBehaviour
{
    public CanvasGroup gameAudioCanvasGroup;
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideGameAudio()
    {
        gameAudioCanvasGroup.alpha=0f;
        gameAudioCanvasGroup.blocksRaycasts=false;
        gameAudioCanvasGroup.interactable=false;
        gameAudioCanvasGroup.ignoreParentGroups=false;
    }

    public void ShowGameAudio()
    {
        gameAudioCanvasGroup.alpha=1f;
        gameAudioCanvasGroup.blocksRaycasts=true;
        gameAudioCanvasGroup.interactable=true;
        gameAudioCanvasGroup.ignoreParentGroups=true;
    }

    public void OnClickGameAudioButton()
    {
        if(gameAudioCanvasGroup.interactable)
        {
            HideGameAudio();
        }
        else
        {
            ShowGameAudio();
        }
    }
}
