using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_Points : MonoBehaviour
{
    public static UI_Points _instance;
    public TextMeshProUGUI pointsText;
    int currentPoint=0;
    int goalPoint=0;
    
    //float startTime=0f;
    //float endTime=0f;
    public float animationTime=2f;
   // int pointRate=0;
    //int timeRate=10;
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

    void AnimatePoints()
    {
        
    }

    void PointCountUp()
    {
        if(currentPoint<goalPoint)
        {
            currentPoint++;
            pointsText.text = currentPoint.ToString();
        }
    }

    public void AddPoints(int newValue)
    {
        goalPoint = newValue;
        StartCoroutine(OnPointsUpdate());
        
    }

    public IEnumerator OnPointsUpdate()
    {
  
        while(currentPoint<goalPoint)
        {
            currentPoint++;
            pointsText.text = currentPoint.ToString();
            yield return new WaitForSeconds(0.3f);
        }
        
    }

}
