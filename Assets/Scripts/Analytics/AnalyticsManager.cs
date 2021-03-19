using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
public class AnalyticsManager : MonoBehaviour
{

    public static AnalyticsManager _instance;
    // Start is called before the first frame update
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

    public void LevelUp(int level_index)
    {
        Debug.Log("Player started level "+level_index);
    }
}
