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
    /// <summary>
    /// Gets Random Color for the cell and plays the show animation
    /// </summary>
    public void Show()
    {
        GetRandomColor();
        iTween.ScaleTo(this.gameObject,iTween.Hash("scale",Vector3.one * 0.42f,"time",0.5f,"name","showcell"));
    }
    /// <summary>
    /// Hides the cell at a random delay time. Once the Hide animation completes calls the Show function
    /// </summary>
    public void Hide()
    {
        iTween.ScaleTo(this.gameObject,iTween.Hash("scale",Vector3.zero,"oncomplete","Show","speed",0.5f,"delay",GetRandomDelay(),"name","hidecell"));
    }
    
    /// <summary>
    /// Hides cell and force stops the hide and show animations
    /// </summary>
    public void HidePermanent()
    {
        iTween.ScaleTo(this.gameObject,iTween.Hash("scale",Vector3.zero,"speed",0.5f));
        
        iTween.StopByName(this.gameObject,"hidecell");
        iTween.StopByName(this.gameObject,"showcell");
    }

    private float GetRandomDelay()
    {
        return Random.Range(minDelay,maxDelay);
    }
}
