using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoadAttribute]
public class EditorManager : MonoBehaviour
{
    // register an event handler when the class is initialized
    static EditorManager()
    {
        EditorApplication.pauseStateChanged += LogPauseState;
    }

    
    

    private static void LogPauseState(PauseState state)
    {
        Debug.Log(state);
    }
}
