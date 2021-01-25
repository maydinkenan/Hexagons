using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalisationSystem 
{

    public enum Language 
    {
        English,
        Turkish,
        German,
        Dutch,
        Spanish,
        French
    }

    public static Language language= Language.Turkish;

    private static Dictionary<string, string> localisedEN;
    private static Dictionary<string, string> localisedTR;

    private static Dictionary<string,string> localisedDE;

    private static Dictionary<string,string> localisedFR;

    private static Dictionary<string,string> localisedES;
    private static Dictionary<string,string> localisedNL;

    public static bool isInit;

    public static void Init()
    {
        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        localisedEN = csvLoader.GetDictionaryValues("en");
        localisedTR = csvLoader.GetDictionaryValues("tr");
        localisedDE = csvLoader.GetDictionaryValues("de");
        localisedES = csvLoader.GetDictionaryValues("es");
        localisedFR = csvLoader.GetDictionaryValues("fr");
        localisedNL = csvLoader.GetDictionaryValues("nl");

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
            case Language.German:
                localisedDE.TryGetValue(key,out value);
                break;
            case Language.French:
                localisedFR.TryGetValue(key,out value);
                break;
            case Language.Spanish:
                localisedES.TryGetValue(key,out value);
                break;
            case Language.Dutch:
                localisedNL.TryGetValue(key,out value);
                break;
        }

        return value;
    }
    
    
}
