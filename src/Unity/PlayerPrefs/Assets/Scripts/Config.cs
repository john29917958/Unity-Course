using System;
using UnityEngine;

[Serializable]
public class Config
{
    public string Name;
    public int Level;
    public float Experience;    

    public void Save()
    {
        string configData = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("config", configData);
        PlayerPrefs.Save();
    }

    public void Refresh()
    {
        Config reloadedConfig = Load();
        Name = reloadedConfig.Name;
        Level = reloadedConfig.Level;
        Experience = reloadedConfig.Experience;
    }

    public static Config Load()
    {
        string configData = PlayerPrefs.GetString("config");
        Config config = JsonUtility.FromJson<Config>(configData);
        if (config == null) config = new Config();
        return config;
    }
}
