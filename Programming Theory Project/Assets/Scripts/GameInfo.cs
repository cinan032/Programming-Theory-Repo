using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    public static GameInfo instance;
    public Record lastRecord;
    public string player;
    string path;

    void Start()
    {
        path = Application.persistentDataPath + "/best.json";
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
        loadRecord();
    }


    [Serializable]
    public class Record // ABSTRACTION
    { 
        public string lastWinner;
    }

    public void saveRecord()
    {
        lastRecord.lastWinner = player;
        File.WriteAllText(path, JsonUtility.ToJson(lastRecord));
    }

    public void loadRecord()
    {
        if (File.Exists(path)) lastRecord = JsonUtility.FromJson<Record>(File.ReadAllText(path));
        else lastRecord.lastWinner = "NA";        
    }
}
