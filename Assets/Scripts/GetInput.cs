using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInput : MonoBehaviour
{
    public enum InputType{
        Single_Click,
        Double_Click
    };

    public static GetInput _instance;

    public InputType inputType = InputType.Single_Click;
    private const float doubleClickTime = 0.2f;
    private float lastClickTime=0f;

    private GameObject tappedObject;

    void Awake()
    {
        if(!_instance)
        {
            _instance = this;
        }
    }
    
    void Update()
    {
        GetDoubleClick();
        
    }
    void GetDoubleClick()
    {
#if UNITY_STANDALONE || UNITY_EDITOR       
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit))
            {
                
                if(hit.transform.gameObject.tag=="cell")
                {
                    //hit.transform.gameObject.GetComponent<HexCell>().CheckNeighbours();
                    
                    GetClicks(hit.transform.gameObject);
                }
            }
            
        }
#endif
#if UNITY_IOS || UNITY_ANDROID

        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            if(Physics.Raycast(ray,out hit))
            {
                
                if(hit.transform.gameObject.tag=="cell")
                {
                    //hit.transform.gameObject.GetComponent<HexCell>().CheckNeighbours();
                    
                    GetClicks(hit.transform.gameObject);
                }
            }
            
        }
#endif
    }

    void GetClicks(GameObject go)
    {

        if(inputType == InputType.Single_Click)
        {
            go.GetComponent<HexCell>().CheckNeighbours();
        }
        else
        {
            float timeSinceLastClick = Time.time - lastClickTime;
            if(timeSinceLastClick <= doubleClickTime)
            {
                //Double Click
            
                if(tappedObject == go)
                {
                    go.GetComponent<HexCell>().CheckNeighbours();
                }
                else
                {
                    tappedObject=go;
                }
            }
            else
            {
                //Single Click
                
                tappedObject=go;
                
            }
            
            lastClickTime = Time.time;
        } 
    }
    public void LoadInputType(InputType newInputType)
    {
        inputType = newInputType;
        int clickMode=1;
        if(newInputType == InputType.Double_Click)
        {
            clickMode =2;
        }
        UI_Options_Manager._instance.SelectClickMode(clickMode);
    }
}
