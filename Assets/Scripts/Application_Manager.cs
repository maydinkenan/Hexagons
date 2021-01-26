using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Application_Manager : MonoBehaviour
{

    public static Application_Manager _instance;
    void Awake()
    {
        if(!_instance)
        {
            _instance=this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnApplicationPause()
    {

    }

    void OnApplicationQuit()
    {
        
    }
}
