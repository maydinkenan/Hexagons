﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CSVLoader 
{
    private TextAsset csvFile;
    private char lineSeperator = '\n';
    private char surrond = '"';
    private string[] fieldSeperator = {"\",\""};

    public void LoadCSV()
    {
        csvFile = Resources.Load<TextAsset>("Localisation");
    }

    public Dictionary<string,string> GetDictionaryValues(string attributeId)
    {
        Dictionary<string,string> dictionary = new Dictionary<string, string>();

        string[] lines = csvFile.text.Split(lineSeperator);

        int attributeIndex = -1;

        string[] headers = lines[0].Split(fieldSeperator,StringSplitOptions.None);

        for(int i=0 ; i < headers.Length; i++)
        {
            if(headers[i].Contains(attributeId))
            {
                attributeIndex = i;
                break;
            }
        }

        Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

        for(int i=0; i<lines.Length; i++)
        {
            string line = lines[i];

            string[] fields = CSVParser.Split(line);

            for(int f = 0; f<fields.Length ; f++)
            {
                fields[f] = fields[f].TrimStart(' ',surrond);
                fields[f] = fields[f].TrimEnd(surrond);
            }

            if(fields.Length> attributeIndex)
            {
                var key = fields[0];

                if(dictionary.ContainsKey(key))
                {
                    continue;
                }

                var value = fields[attributeIndex];
                dictionary.Add(key,value);
            }
        }

        return dictionary;
    }
}
