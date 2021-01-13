using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Animations : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowItemScaleUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowItemScaleUp()
    {
        iTween.ScaleFrom(this.gameObject,Vector3.zero,Random.Range(0.1f,1f));
    }

    public void HideItemScaleDown()
    {
        iTween.ScaleTo(this.gameObject,Vector3.zero,0.5f);
    }
}
