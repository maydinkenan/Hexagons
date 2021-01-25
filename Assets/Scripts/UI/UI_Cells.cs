using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Cells : MonoBehaviour
{
    Color cellColor=Color.white;

    private float minDelay=1f;
    private float maxDelay=5f;
    
    // Start is called before the first frame update
    void Start()
    {
        GetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetRandomColor()
    {
        cellColor = Game_Manager._instance.GetColor();
        this.gameObject.GetComponent<Renderer>().material.color = cellColor;
    }

    public void Show()
    {
        GetRandomColor();
        iTween.ScaleTo(this.gameObject,iTween.Hash("scale",Vector3.one * 0.42f,"time",0.5f));
    }

    public void Hide()
    {
        iTween.ScaleTo(this.gameObject,iTween.Hash("scale",Vector3.zero,"oncomplete","Show","speed",0.5f,"delay",GetRandomDelay()));
    }

    public void HidePermanent()
    {
        iTween.ScaleTo(this.gameObject,iTween.Hash("scale",Vector3.zero,"speed",0.5f));
    }

    private float GetRandomDelay()
    {
        return Random.Range(minDelay,maxDelay);
    }
}
