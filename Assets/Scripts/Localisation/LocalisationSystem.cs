using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalisationSystem 
{

    public enum Language 
    {
        English,
        Turkish
    }

    public static Language language= Language.Turkish;

    private static Dictionary<string, string> localisedEN;
    private static Dictionary<string, string> localisedTR;

    public static bool isInit;

    public static void Init()
    {
        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        localisedEN = csvLoader.GetDictionaryValues("en");
        localisedTR = csvLoader.GetDictionaryValues("tr");

        isInit = true;
    }

    public static string GetLocalisedValue(string key)
    {
        if(!isInit)
        {
            Init();
        }

        string value = key;

        switch(language)
        {
            case Language.English:
                localisedEN.TryGetValue(key, out value);
                break;
            case Language.Turkish:
                localisedTR.TryGetValue(key,out value);
                break;
        }

        return value;
    }
    
    
}
