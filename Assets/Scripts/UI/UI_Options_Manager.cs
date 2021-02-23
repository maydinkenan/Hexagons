using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Options_Manager : MonoBehaviour
{

    public static UI_Options_Manager _instance;
    [SerializeField]
    private UI_Options_Handler[] options_menus;
    // Start is called before the first frame update
    void Awake()
    {
        if(!_instance)
        {
            _instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void HideAllOptions()
    {
        for(int i = 0 ; i < options_menus.Length ; i++)
        {
            options_menus[i].HideOptionMenu();
        }
    }

    public void ShowOptionsMenu(int menu_id)
    {
        for(int i = 0; i < options_menus.Length ; i ++)
        {
            if(i != menu_id )
            {
                options_menus[i].HideOptionMenu();
            }
            /*else
            {
                options_menus[i].ShowOptionsMenu();
            }*/
        }
    }
}
