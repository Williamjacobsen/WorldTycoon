using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Collections;
public class JSONReader
{   
    private string path;
    private string jsonString;
 
    public Progress GetProgress()
    {
        // for some reason, i cant read json file on build
        // do to it taking at least 10 minutes to build, i do not have time to figure out why...
        Progress progress = new Progress();
        progress.Money = 0;
        progress.Ethics = 1000;
        progress.RegionsUnlocked[0] = "North America";
        return progress;

        //path = Application.dataPath + "/StreamingAssets/Progress.json";
        //jsonString = File.ReadAllText(path);

        //Progress progress = JsonUtility.FromJson<Progress>(jsonString);
        //return progress;
    }
}

public class Progress
{
    public int Money;
    public int Ethics;
    public string[] RegionsUnlocked;
}
