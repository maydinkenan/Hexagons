using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HighScore_Manager : MonoBehaviour
{
    public static HighScore_Manager _instance;

    
    public TextMeshProUGUI playerHighScoreLabel;
    void Awake()
    {
        if(!_instance)
        {
            _instance=this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHighScore(int newScore)
    {
        playerHighScoreLabel.text = newScore.ToString();
    }
}
