using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Animations : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float minTime = UI_Manager._instance.GetMinTime();
        float maxTime = UI_Manager._instance.GetMaxTime();
        ShowItemScaleUp(minTime,maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowItemScaleUp(float minTime,float maxTime)
    {
        iTween.ScaleFrom(this.gameObject,Vector3.zero,Random.Range(minTime,maxTime));
    }

    public void HideItemScaleDown(float minTime, float maxTime)
    {
        iTween.ScaleTo(this.gameObject,Vector3.zero,Random.Range(minTime,maxTime));
    }
}
